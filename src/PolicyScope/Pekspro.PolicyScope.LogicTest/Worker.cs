﻿// This file has been autogenerated via
// Pekspro.PolicyScope.CodeGenerator.LogicTest.WorkerGenerator

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pekspro.PolicyScope.LogicTest.Workers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pekspro.PolicyScope.LogicTest
{
    public class Worker : BackgroundService
    {
        public Worker(IServiceScopeFactory serviceScopeFactory, IHostApplicationLifetime hostApplicationLifetime)
        {
            ServiceProviderFactory = serviceScopeFactory;
            HostApplicationLifetime = hostApplicationLifetime;
        }

        public IServiceScopeFactory ServiceProviderFactory { get; }

        public IHostApplicationLifetime HostApplicationLifetime { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(100);
            Console.WriteLine();

            using (var scope = ServiceProviderFactory.CreateScope())
            {
                ILogic logic = scope.ServiceProvider.GetService<ILogic>();
                Console.WriteLine($"Running {nameof(logic.RunWithNoResultNoServiceAsync)}...");
                await logic.RunWithNoResultNoServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult1ServiceAsync)}...");
                await logic.RunWithNoResult1ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult2ServiceAsync)}...");
                await logic.RunWithNoResult2ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult3ServiceAsync)}...");
                await logic.RunWithNoResult3ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult4ServiceAsync)}...");
                await logic.RunWithNoResult4ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithResultNoServiceAsync)}...");
                await logic.RunWithResultNoServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithResult1ServiceAsync)}...");
                await logic.RunWithResult1ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithResult2ServiceAsync)}...");
                await logic.RunWithResult2ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithResult3ServiceAsync)}...");
                await logic.RunWithResult3ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithResult4ServiceAsync)}...");
                await logic.RunWithResult4ServiceAsync();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResultNoService)}...");
                logic.RunWithNoResultNoService();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult1Service)}...");
                logic.RunWithNoResult1Service();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult2Service)}...");
                logic.RunWithNoResult2Service();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult3Service)}...");
                logic.RunWithNoResult3Service();

                Console.WriteLine($"Running {nameof(logic.RunWithNoResult4Service)}...");
                logic.RunWithNoResult4Service();

                Console.WriteLine($"Running {nameof(logic.RunWithResultNoService)}...");
                logic.RunWithResultNoService();

                Console.WriteLine($"Running {nameof(logic.RunWithResult1Service)}...");
                logic.RunWithResult1Service();

                Console.WriteLine($"Running {nameof(logic.RunWithResult2Service)}...");
                logic.RunWithResult2Service();

                Console.WriteLine($"Running {nameof(logic.RunWithResult3Service)}...");
                logic.RunWithResult3Service();

                Console.WriteLine($"Running {nameof(logic.RunWithResult4Service)}...");
                logic.RunWithResult4Service();

            }

            Console.WriteLine();

            HostApplicationLifetime.StopApplication();
        }
    }
}
