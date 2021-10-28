﻿using Autofac;
using BeeManagerLibrary.Repository;
using BeeManagerLibrary.Services;
using BeeManagerLibrary.Views;

namespace BM_ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Views.ProductionView>().As<Views.IProductionView>();
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
