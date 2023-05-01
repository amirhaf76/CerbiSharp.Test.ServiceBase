using CerbiSharp.Test.ServiceBase.Core.AppConfigModel;
using CerbiSharp.Test.ServiceBase.Core.Scenarios;
using CerbiSharp.Test.ServiceBase.Core.TestEnvironmentCore;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace CerbiSharp.Test.ServiceBase.Scenarios
{
    [Order((int)ApiScenariosOrder.BaseTestAppScenario)]
    public class BaseTestAppScenario : BaseTestCaseScenario
    {
        private readonly TestEnvironment _testEnvironment;

        public BaseTestAppScenario(AppConfiguration totalConfiguration, ITestOutputHelper testOutputHelper) : base(totalConfiguration, testOutputHelper)
        {
            _testEnvironment = ResolveService<TestEnvironment>();
        }

        [Fact]
        public void TestSampleTestCase()
        {
            _testEnvironment.AdminSettings.Should().NotBeNull();
            _testEnvironment.DelaySettings.Should().NotBeNull();

            _testEnvironment.DelaySettings.ShortDelay.Should().NotBe(TimeSpan.Zero);
            _testEnvironment.DelaySettings.MediumDelay.Should().NotBe(TimeSpan.Zero);
            _testEnvironment.DelaySettings.LongDelay.Should().NotBe(TimeSpan.Zero);

            _testEnvironment.AdminSettings.Domain.Should().NotBe(0);
            _testEnvironment.AdminSettings.Username.Should().NotBeNullOrEmpty();
            _testEnvironment.AdminSettings.ClientId.Should().NotBeNullOrEmpty();


            var eventId = new EventId(45, "SimpleExample");
            Logger.LogInformation(eventId, "Simple test run correctly.");
        }
    }
}