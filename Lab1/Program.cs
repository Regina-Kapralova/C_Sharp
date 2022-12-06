using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
namespace PickyBrideProblem
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Princess>();
                    services.AddScoped<Hall>();
                    services.AddScoped<IHallForPrincess>(sp => sp.GetRequiredService<Hall>());
                    services.AddScoped<IHallForFriend>(sp => sp.GetRequiredService<Hall>());
                    services.AddScoped<Friend>();
                    services.AddScoped<ContenderGenerator>();
                });
        }
    }
}
