using BeeManagerLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BeeManagerMVC
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            DataGenerator.Initialize();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
