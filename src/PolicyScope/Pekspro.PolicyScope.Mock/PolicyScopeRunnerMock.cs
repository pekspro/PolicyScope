﻿// This file has been autogenerated via
// Pekspro.PolicyScope.CodeGenerator.Mock.PolicyScopeRunnerMockGenerator

using System;
using System.Threading.Tasks;

namespace Pekspro.PolicyScope.Mock
{
    internal class AsyncNoServiceNoResultPolicyScopeRunnerMock : IAsyncNoServiceNoResultPolicyScopeRunner
    {
        internal AsyncNoServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task RunAsync(Func<Task> func)
        {
            await func.Invoke().ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunnerMock<T> : IAsyncServiceNoResultPolicyScopeRunner<T>
    {
        internal AsyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task RunAsync(Func<T, Task> func)
        {
            var t = (T) PolicyScopeMockConfiguration.ServiceInstances[0];

            await func.Invoke(t).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunnerMock<T1, T2> : IAsyncServiceNoResultPolicyScopeRunner<T1, T2>
    {
        internal AsyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task RunAsync(Func<T1, T2, Task> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];

            await func.Invoke(t1, t2).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunnerMock<T1, T2, T3> : IAsyncServiceNoResultPolicyScopeRunner<T1, T2, T3>
    {
        internal AsyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task RunAsync(Func<T1, T2, T3, Task> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];

            await func.Invoke(t1, t2, t3).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunnerMock<T1, T2, T3, T4> : IAsyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4>
    {
        internal AsyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task RunAsync(Func<T1, T2, T3, T4, Task> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];
            var t4 = (T4) PolicyScopeMockConfiguration.ServiceInstances[3];

            await func.Invoke(t1, t2, t3, t4).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class AsyncNoServiceResultPolicyScopeRunnerMock<TResult> : IAsyncNoServiceResultPolicyScopeRunner<TResult>
    {
        internal AsyncNoServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task<TResult> RunAsync(Func<Task<TResult>> func)
        {
            TResult retValue = await func.Invoke().ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunnerMock<T, TResult> : IAsyncServiceResultPolicyScopeRunner<T, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task<TResult> RunAsync(Func<T, Task<TResult>> func)
        {
            var t = (T) PolicyScopeMockConfiguration.ServiceInstances[0];

            TResult retValue = await func.Invoke(t).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunnerMock<T1, T2, TResult> : IAsyncServiceResultPolicyScopeRunner<T1, T2, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task<TResult> RunAsync(Func<T1, T2, Task<TResult>> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];

            TResult retValue = await func.Invoke(t1, t2).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunnerMock<T1, T2, T3, TResult> : IAsyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task<TResult> RunAsync(Func<T1, T2, T3, Task<TResult>> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];

            TResult retValue = await func.Invoke(t1, t2, t3).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunnerMock<T1, T2, T3, T4, TResult> : IAsyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public async Task<TResult> RunAsync(Func<T1, T2, T3, T4, Task<TResult>> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];
            var t4 = (T4) PolicyScopeMockConfiguration.ServiceInstances[3];

            TResult retValue = await func.Invoke(t1, t2, t3, t4).ConfigureAwait(false);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class SyncNoServiceNoResultPolicyScopeRunnerMock : ISyncNoServiceNoResultPolicyScopeRunner
    {
        internal SyncNoServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public void Run(Action func)
        {
             func.Invoke();

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunnerMock<T> : ISyncServiceNoResultPolicyScopeRunner<T>
    {
        internal SyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public void Run(Action<T> func)
        {
            var t = (T) PolicyScopeMockConfiguration.ServiceInstances[0];

             func.Invoke(t);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunnerMock<T1, T2> : ISyncServiceNoResultPolicyScopeRunner<T1, T2>
    {
        internal SyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public void Run(Action<T1, T2> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];

             func.Invoke(t1, t2);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunnerMock<T1, T2, T3> : ISyncServiceNoResultPolicyScopeRunner<T1, T2, T3>
    {
        internal SyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public void Run(Action<T1, T2, T3> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];

             func.Invoke(t1, t2, t3);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunnerMock<T1, T2, T3, T4> : ISyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4>
    {
        internal SyncServiceNoResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public void Run(Action<T1, T2, T3, T4> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];
            var t4 = (T4) PolicyScopeMockConfiguration.ServiceInstances[3];

             func.Invoke(t1, t2, t3, t4);

            PolicyScopeMockConfiguration.ExecutionCount++;
        }
    }

    internal class SyncNoServiceResultPolicyScopeRunnerMock<TResult> : ISyncNoServiceResultPolicyScopeRunner<TResult>
    {
        internal SyncNoServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public TResult Run(Func<TResult> func)
        {
            TResult retValue =  func.Invoke();

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunnerMock<T, TResult> : ISyncServiceResultPolicyScopeRunner<T, TResult>
    {
        internal SyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public TResult Run(Func<T, TResult> func)
        {
            var t = (T) PolicyScopeMockConfiguration.ServiceInstances[0];

            TResult retValue =  func.Invoke(t);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunnerMock<T1, T2, TResult> : ISyncServiceResultPolicyScopeRunner<T1, T2, TResult>
    {
        internal SyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public TResult Run(Func<T1, T2, TResult> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];

            TResult retValue =  func.Invoke(t1, t2);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunnerMock<T1, T2, T3, TResult> : ISyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult>
    {
        internal SyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public TResult Run(Func<T1, T2, T3, TResult> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];

            TResult retValue =  func.Invoke(t1, t2, t3);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunnerMock<T1, T2, T3, T4, TResult> : ISyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult>
    {
        internal SyncServiceResultPolicyScopeRunnerMock(PolicyScopeMockConfiguration policyScopeMockConfiguration)
        {
            PolicyScopeMockConfiguration = policyScopeMockConfiguration;
        }

        internal PolicyScopeMockConfiguration PolicyScopeMockConfiguration { get; }

        public TResult Run(Func<T1, T2, T3, T4, TResult> func)
        {
            var t1 = (T1) PolicyScopeMockConfiguration.ServiceInstances[0];
            var t2 = (T2) PolicyScopeMockConfiguration.ServiceInstances[1];
            var t3 = (T3) PolicyScopeMockConfiguration.ServiceInstances[2];
            var t4 = (T4) PolicyScopeMockConfiguration.ServiceInstances[3];

            TResult retValue =  func.Invoke(t1, t2, t3, t4);

            PolicyScopeMockConfiguration.ExecutionCount++;

            return retValue;
        }
    }

}
