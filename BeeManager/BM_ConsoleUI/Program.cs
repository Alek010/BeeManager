using Autofac;
using BeeManagerLibrary;
using System;
using System.Text;

namespace BM_ConsoleUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            Console.OutputEncoding = Encoding.UTF8;

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
