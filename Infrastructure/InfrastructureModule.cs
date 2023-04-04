using Autofac;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
    }
}