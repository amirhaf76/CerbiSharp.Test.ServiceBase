using Autofac;
using CerbiSharp.Templates.TestSample.Core.DIModules;
using CerbiSharp.Templates.TestSample.Core.Logging;
using Divergic.Logging.Xunit;

namespace CerbiSharp.Templates.TestSample.Core.AppConfigModel
{
    public class AppConfiguration
    {
        private readonly IContainer _container;

        public LoggingConfig LoggingConfig { get; private set; }

        public AppConfiguration()
        {
            var builder = new ContainerBuilder();

            _container = RegisterDependencies(builder).Build();

            LoggingConfig = new APITestLoggingConfig();
        }

        private static ContainerBuilder RegisterDependencies(ContainerBuilder builder)
        {
            var apiTestDIModule = typeof(APITestDIModule).Assembly;

            builder.RegisterAssemblyModules(apiTestDIModule);

            return builder;
        }

        public ILifetimeScope CreateScope()
        {
            return _container.BeginLifetimeScope();
        }

        public ILifetimeScope CreateScope(Action<ContainerBuilder> action)
        {
            return _container.BeginLifetimeScope(action);
        }
    }
}
