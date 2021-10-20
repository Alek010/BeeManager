using Autofac;
using BM_ConsoleUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ProductionByYear>().As<IProductionByYear>();

            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            builder.RegisterType<ProductionStorage>().As<IProductionStorage>();
            builder.RegisterType<UnitsOfMeasurementStorage>().As<IUnitsOfMeasurementStorage>();

            builder.RegisterType<ProductServices>().As<IProductServices>();
            builder.RegisterType<ProductionServices>().As<IProductionServices>();
            builder.RegisterType<UnitsOfMeasurementServices>().As<IUnitsOfMeasurementServices>();


            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(BM_ConsoleUI)))
            //    .Where(t => t.Namespace.Contains("Repository"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(BM_ConsoleUI)))
            //    .Where(t => t.Namespace.Contains("Services"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
