using Autofac;
using AwesomeApp.Core.Interfaces;
using AwesomeApp.Core.Services;

namespace AwesomeApp.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
