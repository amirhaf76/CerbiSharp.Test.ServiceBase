using CerbiSharp.Test.ServiceBase.Core.AppConfigModel;
using CerbiSharp.Test.ServiceBase.Core.Scenarios;
using CerbiSharp.Test.ServiceBase.SettingsModels;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace CerbiSharp.Test.ServiceBase.Scenarios
{
    [Order((int)ScenariosOrder.BaseTestAppScenario)]
    public class BaseTestAppScenario : BaseTestCaseScenario
    {
        private readonly DelaySettings _delaySettings;
        private readonly ILogger<BaseTestAppScenario> _logger;

        public BaseTestAppScenario(AppConfiguration totalConfiguration, ITestOutputHelper testOutputHelper) : base(totalConfiguration, testOutputHelper)
        {
            _logger = ResolveService<ILogger<BaseTestAppScenario>>();
            _delaySettings = ResolveService<DelaySettings>();
        }

        [Fact]
        public void TestSampleTestCase()
        {
            _delaySettings.Should().NotBeNull();

            _delaySettings.ShortDelay.Should().NotBe(TimeSpan.Zero);
            _delaySettings.MediumDelay.Should().NotBe(TimeSpan.Zero);
            _delaySettings.LongDelay.Should().NotBe(TimeSpan.Zero);

            _logger.LogInformation("{@delaySettings}", _delaySettings);
            _logger.LogDebug("Simple test run correctly.");

        }
    }
}