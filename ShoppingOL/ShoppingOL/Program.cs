using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingOL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingOL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //Seedig happens during startup the application
            RunSeeding(host);

            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<ShoppingolSeeder>();
                seeder.Seed();
            }            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            //Removing the default configuration options
            builder.Sources.Clear();
            //Auto-reload the Json file when it's changed
            builder.AddJsonFile("config.json", false, true)
                .AddXmlFile("config.xml",true)
                .AddEnvironmentVariables();           

        }
    }
}
