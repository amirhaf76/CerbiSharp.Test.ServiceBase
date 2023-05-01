using CerbiSharp.Infrastructure.BaseInfrastructure.AutoFac.FlagInterface;
using CerbiSharp.Infrastructure.BaseInfrastructure.Tools;
using CerbiSharp.Test.ServiceBase.SettingsModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CerbiSharp.Test.ServiceBase.Core.TestEnvironmentCore
{
    public class TestEnvironment : IScope
    {
        private readonly ILogger _logger;

        private void SetConfigs()
        {
            AdminSettings = GetAdminSettingsFromConfig();

            DelaySettings = GetDelaySettingsFromConfig();
        }

        public TestEnvironment(ILogger logger)
        {
            _logger = logger;

            SetConfigs();
        }


        public AdminSettings AdminSettings { get; private set; }

        public DelaySettings DelaySettings { get; set; }


        private AdminSettings GetAdminSettingsFromConfig()
        {
            var config = GetConfig<AdminSettings>("appconfigs.json", "adminSettings");
            _logger.LogInformation("{config}", Helper.GetPropertyValuesInString(config));

            return config;
        }

        private DelaySettings GetDelaySettingsFromConfig()
        {
            var config = GetConfig<DelaySettings>("appconfigs.json", "delaySettings");
            _logger.LogInformation("{config}", Helper.GetPropertyValuesInString(config));

            return config;
        }

        private static T GetConfig<T>(string fileName, string sectionName)
        {
            return GetConfigFromDirectory(fileName)
                .GetSection(sectionName)
                .Get<T>();
        }

        private static IConfigurationRoot GetConfigFromDirectory(string fileName)
        {
            return new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile($@"Config/{fileName}")
                            .Build();
        }

    }
}
