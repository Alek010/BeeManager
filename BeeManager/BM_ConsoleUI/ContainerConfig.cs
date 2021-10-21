using Autofac;
using BM_ConsoleUI.Services;
using BM_ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            builder.RegisterType<ProductionView>().As<IProductionView>();
            builder.RegisterType<ProductionSummaryView>().As<IProductionSummaryView>();

            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            builder.RegisterType<ProductionStorage>().As<IProductionStorage>();
            builder.RegisterType<UnitsOfMeasurementStorage>().As<IUnitsOfMeasurementStorage>();

            builder.RegisterType<ProductServices>().As<IProductServices>();
            builder.RegisterType<ProductionServices>().As<IProductionServices>();
            builder.RegisterType<UnitsOfMeasurementServices>().As<IUnitsOfMeasurementServices>();

            return builder.Build();
        }
    }
}
