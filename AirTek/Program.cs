using Microsoft.Extensions.DependencyInjection;
using AirTek.Database.Extensions;
using AirTek.Interfaces;
using AirTek.Services;
using System;

namespace AirTek {
    internal class Program {
        static void Main(string[] args) {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDatabaseServices();
            serviceCollection.AddScoped<IPrintJsonService, PrintJsonService>();
            serviceCollection.AddScoped<IPrintTextService, PrintTextService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            FirstScenario(serviceProvider);
            Console.WriteLine("");
            SecondScenario(serviceProvider);
        }

        static void FirstScenario(ServiceProvider serviceProvider) {
            var printTextService = serviceProvider.GetService<IPrintTextService>();

            printTextService.Print();
        }

        static void SecondScenario(ServiceProvider serviceProvider) {
            var printJsonService = serviceProvider.GetService<IPrintJsonService>();

            printJsonService.Print();
        }
    }
}
