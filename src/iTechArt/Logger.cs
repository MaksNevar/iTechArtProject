using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace iTechArt.Common
{
    public sealed class Logger : ILog
    {
        private readonly ILogger _logger;


        public Logger(ILogger logger)
        {
            _logger = logger;
        }


        public void Log(LogLevel level, string message)
        {
            _logger.Write((LogEventLevel)level, message);
        }
    }
}