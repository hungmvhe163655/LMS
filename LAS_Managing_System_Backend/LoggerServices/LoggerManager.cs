
using Contracts.Interfaces;
using NLog;

namespace LoggerServices
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager() { }

        public void LogDebuger(string messages) => logger.Debug(messages);

        public void LogError(string messages) => logger.Error(messages);

        public void LogInformation(string messages) => logger.Info(messages);

        public void LogWarning(string messages) => logger.Warn(messages);
    }
}