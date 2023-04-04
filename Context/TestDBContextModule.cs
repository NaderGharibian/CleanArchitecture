using Autofac;
using Context.Interfaces;
using Context.Repositories;

namespace Context;

public class TestDBContextModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TestDBRepository>().As<ITestDBRepository>().InstancePerLifetimeScope();
    }
}