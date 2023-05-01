using Autofac;
using Autofac.Core;
using CerbiSharp.Test.ServiceBase.Core.AppConfigModel;
using Divergic.Logging.Xunit;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace CerbiSharp.Test.ServiceBase.Core.Scenarios
{
    public class BaseTestCaseScenario : LoggingTestsBase<BaseTestCaseScenario>, IAssemblyFixture<AppConfiguration>, IDisposable
    {
        protected readonly AppConfiguration _totalConfiguration;
        private readonly ILifetimeScope _scope;

        public BaseTestCaseScenario(AppConfiguration totalConfiguration, ITestOutputHelper testOutputHelper)
            : base(testOutputHelper, totalConfiguration.LoggingConfig)
        {
            _totalConfiguration = totalConfiguration;

            _scope = totalConfiguration.CreateScope(b => b.RegisterInstance<ILogger>(Logger));
        }

        protected T ResolveService<T>()
        {
            return _scope.Resolve<T>();
        }

        protected T ResolveService<T>(params Parameter[] parameters)
        {
            return _scope.Resolve<T>(parameters);
        }

        protected override void Dispose(bool disposing)
        {
            _scope.Dispose();

            base.Dispose(disposing);
        }
    }
}
