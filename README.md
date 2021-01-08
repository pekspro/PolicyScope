# PolicyScope

PolicyScope makes it easier to use [Polly](https://github.com/App-vNext/Polly)
combined with `IServiceScopeFactory` in .NET Core / .NET 5+. It also makes it
easy to write unit tests.

PolicyScope is not trying to use replace Polly. It also not supporting every
feature in Polly. And it might not be the right choice in every situation. But
if you are using Polly and using dependency injection it may be a good choice.

![Build and Test](https://github.com/pekspro/PolicyScope/workflows/Build%20and%20Test/badge.svg)

## Why PolicyScope?

Let us compare some code with and without PolicyScope.

### Code without PolicySope

Here is an example how you could use Polly with `IServiceScopeFactory` without
PolicyScope:

```csharp
public class WithoutPolicyScope
{
    public WithoutPolicyScope(IServiceScopeFactory serviceScopeFactory, IReadOnlyPolicyRegistry<string> policyRegistry)
    {
        ServiceScopeFactory = serviceScopeFactory;
        PolicyRegistry = policyRegistry;
    }

    public IServiceScopeFactory ServiceScopeFactory { get; }
    
    public IReadOnlyPolicyRegistry<string> PolicyRegistry { get; }

    public async Task<int> UpdateWithoutPolicyScopeAsync()
    {
        int retValue = -1;

        var policy = PolicyRegistry.Get<IAsyncPolicy>(PolicyNames.Primary);

        await policy.ExecuteAsync(async () =>
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MyDatabaseContext>()!;
                var manipulator = scope.ServiceProvider.GetService<IDatabaseUpdater>()!;

                retValue = await manipulator.UpdateAsync(context).ConfigureAwait(false);
            }
        });

        return retValue;
    }
}
```

You need to inject both `IServiceScopeFactory` and `IReadOnlyPolicyRegistry` on
your objects. In the function you need to select which policy to use, create a
scope when the policy is executing and request the services you need. This works
but there is some boiler plate code to write.

### Code with PolicyScope

Here is the equivalent code with PolicyScope:

```csharp
public class WithPolicyScope
{
    internal IPolicyScopeBuilder PolicyScopeBuilder { get; }

    public WithPolicyScope(IPolicyScopeBuilder policyScopeBuilder)
    {
        PolicyScopeBuilder = policyScopeBuilder;
    }

    public Task<int> UpdateWithPolicyScopeAsync()
    {
        return PolicyScopeBuilder
                    .WithAsyncPolicy(PolicyNames.Primary)
                    .WithServices<MyDatabaseContext, IDatabaseUpdater>()
                    .WithResult<int>()
                    .RunAsync(async (myDatabaseContext, databaseManipulator) =>
                    {
                        return await databaseManipulator.UpdateAsync(myDatabaseContext);
                    });
    }
}
```

A lot less code, and the code use more readable.

### Unit test without PolicyScope

Here is an example how you could create a unit test without PolicyScope for the code above:

```csharp
[Fact]
public async Task TestUpdateWithoutPolicyScopeAsync()
{
    // Arrange
    MyDatabaseContext myDatabaseContext = new MyDatabaseContext();
    Mock<IDatabaseUpdater> databaseManipulator = new Mock<IDatabaseUpdater>();

    databaseManipulator
        .Setup(d => d.UpdateAsync(myDatabaseContext))
        .Returns(Task.FromResult(42));

    Mock<IServiceScopeFactory> serviceScopeFactory = new Mock<IServiceScopeFactory>();
    Mock<IServiceScope> serviceScope = new Mock<IServiceScope>();
    Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();
    Mock<IReadOnlyPolicyRegistry<string>> policyRegistry = new Mock<IReadOnlyPolicyRegistry<string>>();
    IAsyncPolicy policy = Policy.NoOpAsync();

    serviceScopeFactory
        .Setup(s => s.CreateScope())
        .Returns(serviceScope.Object);

    serviceScope
        .Setup(s => s.ServiceProvider)
        .Returns(serviceProvider.Object);

    serviceProvider
        .Setup(s => s.GetService(typeof(MyDatabaseContext)))
        .Returns(myDatabaseContext);

    serviceProvider
        .Setup(s => s.GetService(typeof(IDatabaseUpdater)))
        .Returns(databaseManipulator.Object);

    policyRegistry
        .Setup(p => p.Get<IAsyncPolicy>(PolicyNames.Primary))
        .Returns(policy);

    WithoutPolicyScope logic = new WithoutPolicyScope(serviceScopeFactory.Object, policyRegistry.Object);

    // Act
    int result = await logic.UpdateWithoutPolicyScopeAsync();

    // Assert
    Assert.Equal(42, result);
}
```

This is a lot of code to make this work.

### Unit test with PolicyScope

With PolicyScope, the code is significantly smaller:

```csharp
[Fact]
public async Task TestUpdateWithPolicyScopeAsync()
{
    // Arrange
    MyDatabaseContext myDatabaseContext = new MyDatabaseContext();
    Mock<IDatabaseUpdater> databaseManipulator = new Mock<IDatabaseUpdater>();

    databaseManipulator
        .Setup(d => d.UpdateAsync(myDatabaseContext))
        .Returns(Task.FromResult(42));

    PolicyScopeMock policyScopeMock = PolicyScopeMock
                    .AsyncPolicy(PolicyNames.Primary)
                    .WithServices(myDatabaseContext, databaseManipulator.Object)
                    .WithResultType<int>()
                    .Build();

    WithPolicyScope logic = new WithPolicyScope(policyScopeMock.Object);

    // Act
    int result = await logic.UpdateWithPolicyScopeAsync();

    // Assert
    policyScopeMock.VerifyRunOnce();
    Assert.Equal(42, result);
}
```

It is also easier to read.

## Installing PolicyScope

It is required that you have configured Polly to be used PolicyRegistry. It should look something like this:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            // Setup polly
            PolicyRegistry policyRegistry = new PolicyRegistry();

            var primaryPolicy = Policy.Handle<Exception>().RetryAsync(1);
            policyRegistry.Add(PolicyNames.Primary, primaryPolicy);

            var secondaryPolicy = Policy.Handle<Exception>().RetryAsync(2);
            policyRegistry.Add(PolicyNames.Secondary, secondaryPolicy);

            // Setup policy registry
            services.AddSingleton<IReadOnlyPolicyRegistry<string>, PolicyRegistry>(a => policyRegistry);
```

And then you just add PolicyScope:

```csharp
            // Add PolicyScope
            services.AddPolicyScope();
```

## Sample

With the code there is a complete sample project showing how to use PolicyScope. The is also sample on how to write unit tests.

## About the code

Except the sample projects, there are these five projects in the code:

### Pekspro.PolicyScope

This is the main library.

### Pekspro.PolicyScope.Mock

This it the library to be used in unit test.

### Pekspro.PolicyScope.CodeGenerator

This project autogenerates some code for the other projects. This is just a simple console application updating necessary files.

### Pekspro.PolicyScope.LogicTest

This is a console application with services that is using several possible scenarios.

### Pekspro.PolicyScope.Test

This is a test project. It is testing most possible scenarios.

## Limitations

PolicyScope is supporting up to four services as the moment. It easy to change this number with the CodeGenerator project.
