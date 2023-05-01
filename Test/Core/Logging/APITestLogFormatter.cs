using CerbiSharp.Infrastructure.BaseInfrastructure.AutoFac.FlagInterface;
using Divergic.Logging.Xunit;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CerbiSharp.Test.ServiceBase.Core.Logging
{
    public class APITestLogFormatter : ILogFormatter, ISingleton
    {
        public string Format(int scopeLevel, string categoryName, LogLevel logLevel, EventId eventId, string message, Exception exception)
        {
            var strBuilder = new StringBuilder();

            if (scopeLevel > 0)
            {
                strBuilder.Append(' ', scopeLevel * 2);
            }

            strBuilder.Append($"[{DateTime.Now}]");
            strBuilder.Append($"[{logLevel}]");

            if (eventId.Id != 0)
            {
                strBuilder.Append($"[Eve:{eventId.Id},{eventId.Name}]");
            }

            strBuilder.Append(": ");

            if (!string.IsNullOrEmpty(message))
            {
                strBuilder.Append(message);
            }

            if (exception != null)
            {
                strBuilder.Append($"\n{exception}");
            }

            return strBuilder.ToString();
        }
    }
}
