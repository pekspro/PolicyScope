﻿// This file has been autogenerated via
// Pekspro.PolicyScope.CodeGenerator.MainLibrary.PolicyScopeRunnerGenerator

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Pekspro.PolicyScope
{
    internal class AsyncNoServiceNoResultPolicyScopeRunner : AsyncPolicyScopeBase, IAsyncNoServiceNoResultPolicyScopeRunner
    {
        internal AsyncNoServiceNoResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task RunAsync(Func<Task> func)
        {
            await Policy.ExecuteAsync(async () =>
            {
                await func.Invoke().ConfigureAwait(false);
            });
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunner<T> : AsyncPolicyScopeBase, IAsyncServiceNoResultPolicyScopeRunner<T>
    {
        internal AsyncServiceNoResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task RunAsync(Func<T, Task> func)
        {
            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t = scope.ServiceProvider.GetService<T>()!;

                    await func.Invoke(t).ConfigureAwait(false);
                }
            });
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunner<T1, T2> : AsyncPolicyScopeBase, IAsyncServiceNoResultPolicyScopeRunner<T1, T2>
    {
        internal AsyncServiceNoResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task RunAsync(Func<T1, T2, Task> func)
        {
            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;

                    await func.Invoke(t1, t2).ConfigureAwait(false);
                }
            });
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunner<T1, T2, T3> : AsyncPolicyScopeBase, IAsyncServiceNoResultPolicyScopeRunner<T1, T2, T3>
    {
        internal AsyncServiceNoResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task RunAsync(Func<T1, T2, T3, Task> func)
        {
            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;

                    await func.Invoke(t1, t2, t3).ConfigureAwait(false);
                }
            });
        }
    }

    internal class AsyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4> : AsyncPolicyScopeBase, IAsyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4>
    {
        internal AsyncServiceNoResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task RunAsync(Func<T1, T2, T3, T4, Task> func)
        {
            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;
                    var t4 = scope.ServiceProvider.GetService<T4>()!;

                    await func.Invoke(t1, t2, t3, t4).ConfigureAwait(false);
                }
            });
        }
    }

    internal class AsyncNoServiceResultPolicyScopeRunner<TResult> : AsyncPolicyScopeBase, IAsyncNoServiceResultPolicyScopeRunner<TResult>
    {
        internal AsyncNoServiceResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task<TResult> RunAsync(Func<Task<TResult>> func)
        {
            TResult retValue = default!;

            await Policy.ExecuteAsync(async () =>
            {
                retValue = await func.Invoke().ConfigureAwait(false);
            });

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunner<T, TResult> : AsyncPolicyScopeBase, IAsyncServiceResultPolicyScopeRunner<T, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task<TResult> RunAsync(Func<T, Task<TResult>> func)
        {
            TResult retValue = default!;

            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t = scope.ServiceProvider.GetService<T>()!;

                    retValue = await func.Invoke(t).ConfigureAwait(false);
                }
            });

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunner<T1, T2, TResult> : AsyncPolicyScopeBase, IAsyncServiceResultPolicyScopeRunner<T1, T2, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task<TResult> RunAsync(Func<T1, T2, Task<TResult>> func)
        {
            TResult retValue = default!;

            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;

                    retValue = await func.Invoke(t1, t2).ConfigureAwait(false);
                }
            });

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult> : AsyncPolicyScopeBase, IAsyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task<TResult> RunAsync(Func<T1, T2, T3, Task<TResult>> func)
        {
            TResult retValue = default!;

            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;

                    retValue = await func.Invoke(t1, t2, t3).ConfigureAwait(false);
                }
            });

            return retValue;
        }
    }

    internal class AsyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult> : AsyncPolicyScopeBase, IAsyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult>
    {
        internal AsyncServiceResultPolicyScopeRunner(AsyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public async Task<TResult> RunAsync(Func<T1, T2, T3, T4, Task<TResult>> func)
        {
            TResult retValue = default!;

            await Policy.ExecuteAsync(async () =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;
                    var t4 = scope.ServiceProvider.GetService<T4>()!;

                    retValue = await func.Invoke(t1, t2, t3, t4).ConfigureAwait(false);
                }
            });

            return retValue;
        }
    }

    internal class SyncNoServiceNoResultPolicyScopeRunner : SyncPolicyScopeBase, ISyncNoServiceNoResultPolicyScopeRunner
    {
        internal SyncNoServiceNoResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public void Run(Action func)
        {
            Policy.Execute(() =>
            {
                 func.Invoke();
            });
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunner<T> : SyncPolicyScopeBase, ISyncServiceNoResultPolicyScopeRunner<T>
    {
        internal SyncServiceNoResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public void Run(Action<T> func)
        {
            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t = scope.ServiceProvider.GetService<T>()!;

                     func.Invoke(t);
                }
            });
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunner<T1, T2> : SyncPolicyScopeBase, ISyncServiceNoResultPolicyScopeRunner<T1, T2>
    {
        internal SyncServiceNoResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public void Run(Action<T1, T2> func)
        {
            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;

                     func.Invoke(t1, t2);
                }
            });
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunner<T1, T2, T3> : SyncPolicyScopeBase, ISyncServiceNoResultPolicyScopeRunner<T1, T2, T3>
    {
        internal SyncServiceNoResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public void Run(Action<T1, T2, T3> func)
        {
            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;

                     func.Invoke(t1, t2, t3);
                }
            });
        }
    }

    internal class SyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4> : SyncPolicyScopeBase, ISyncServiceNoResultPolicyScopeRunner<T1, T2, T3, T4>
    {
        internal SyncServiceNoResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public void Run(Action<T1, T2, T3, T4> func)
        {
            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;
                    var t4 = scope.ServiceProvider.GetService<T4>()!;

                     func.Invoke(t1, t2, t3, t4);
                }
            });
        }
    }

    internal class SyncNoServiceResultPolicyScopeRunner<TResult> : SyncPolicyScopeBase, ISyncNoServiceResultPolicyScopeRunner<TResult>
    {
        internal SyncNoServiceResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public TResult Run(Func<TResult> func)
        {
            TResult retValue = default!;

            Policy.Execute(() =>
            {
                retValue =  func.Invoke();
            });

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunner<T, TResult> : SyncPolicyScopeBase, ISyncServiceResultPolicyScopeRunner<T, TResult>
    {
        internal SyncServiceResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public TResult Run(Func<T, TResult> func)
        {
            TResult retValue = default!;

            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t = scope.ServiceProvider.GetService<T>()!;

                    retValue =  func.Invoke(t);
                }
            });

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunner<T1, T2, TResult> : SyncPolicyScopeBase, ISyncServiceResultPolicyScopeRunner<T1, T2, TResult>
    {
        internal SyncServiceResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public TResult Run(Func<T1, T2, TResult> func)
        {
            TResult retValue = default!;

            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;

                    retValue =  func.Invoke(t1, t2);
                }
            });

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult> : SyncPolicyScopeBase, ISyncServiceResultPolicyScopeRunner<T1, T2, T3, TResult>
    {
        internal SyncServiceResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public TResult Run(Func<T1, T2, T3, TResult> func)
        {
            TResult retValue = default!;

            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;

                    retValue =  func.Invoke(t1, t2, t3);
                }
            });

            return retValue;
        }
    }

    internal class SyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult> : SyncPolicyScopeBase, ISyncServiceResultPolicyScopeRunner<T1, T2, T3, T4, TResult>
    {
        internal SyncServiceResultPolicyScopeRunner(SyncPolicyScopeBase settings)
            : base(settings)
        {
        }

        public TResult Run(Func<T1, T2, T3, T4, TResult> func)
        {
            TResult retValue = default!;

            Policy.Execute(() =>
            {
                using (var scope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var t1 = scope.ServiceProvider.GetService<T1>()!;
                    var t2 = scope.ServiceProvider.GetService<T2>()!;
                    var t3 = scope.ServiceProvider.GetService<T3>()!;
                    var t4 = scope.ServiceProvider.GetService<T4>()!;

                    retValue =  func.Invoke(t1, t2, t3, t4);
                }
            });

            return retValue;
        }
    }
}
