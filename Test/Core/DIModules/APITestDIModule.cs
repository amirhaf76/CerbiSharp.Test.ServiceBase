using Autofac;
using CerbiSharp.Infrastructure.BaseInfrastructure.AutoFac;
using CerbiSharp.Test.ServiceBase.SettingsModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Extensions.Autofac.DependencyInjection;
using Xunit.Abstractions;

namespace CerbiSharp.Test.ServiceBase.Core.DIModules
{
    public class APITestDIModule : BaseDIModule<APITestDIModule>
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c =>
                {
                    return c.Resolve<IConfiguration>().GetSection("delaySettings").Get<DelaySettings>();
                })
                .InstancePerLifetimeScope()
                .AsSelf();

            base.Load(builder);
        }

    }
}
