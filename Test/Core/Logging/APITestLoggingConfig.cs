using CerbiSharp.Infrastructure.BaseInfrastructure.AutoFac.FlagInterface;
using Divergic.Logging.Xunit;

namespace CerbiSharp.Test.ServiceBase.Core.Logging
{
    public class APITestLoggingConfig : LoggingConfig, ISingleton
    {
        public APITestLoggingConfig(ILogFormatter logFormatter)
        {
            Formatter = logFormatter;
        }

        public APITestLoggingConfig() : this(new APITestLogFormatter())
        {

        }
    }
}
