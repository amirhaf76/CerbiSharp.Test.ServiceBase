using Autofac;
using CerbiSharp.Infrastructure.BaseInfrastructure.AutoFac;

namespace CerbiSharp.Test.ServiceBase.Core.DIModules
{
    public class APITestDIModule : BaseDIModule<APITestDIModule>
    {
        protected override void Load(ContainerBuilder builder)
        {

            base.Load(builder);
        }

    }
}
