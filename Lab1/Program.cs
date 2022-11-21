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
                    Hall hall = new Hall();
                    services.AddHostedService<Princess>();
                    services.AddScoped<IHallForPrincess>(sp => hall);
                    services.AddScoped<IHallForFriend>(sp => hall);
                    services.AddScoped<Friend>();
                    services.AddScoped<ContenderGenerator>();
                });
        }

    }
}
