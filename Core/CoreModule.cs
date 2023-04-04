using Autofac;
using Core.Interfaces.UseCases;
using Core.UseCases.Requests;
using Core.UseCases.Responses;

namespace Core;

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateCustomerRequestUseCase>().As<ICreateCustomerRequestUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ReadCustomerRequestUseCase>().As<IReadCustomerRequestUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteCustomerRequestUseCase>().As<IDeleteCustomerRequestUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateCustomerRequestUseCase>().As<IUpdateCustomerRequestUseCase>().InstancePerLifetimeScope();
        
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(o => o.FullName.StartsWith("Infrastructure,")).ToArray();
            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterType<CreateCustomerResponseUseCase>().SingleInstance();
            builder.RegisterType<ReadCustomerResponseUseCase>().SingleInstance();
            builder.RegisterType<DeleteCustomerResponseUseCase>().SingleInstance();
            builder.RegisterType<UpdateCustomerResponseUseCase>().SingleInstance();
        }
    }