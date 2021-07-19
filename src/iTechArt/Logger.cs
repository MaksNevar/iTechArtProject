using System;
using System.IO;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace iTechArt.Common
{
    public sealed class Logger : ILog
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger) => _logger = logger;

        public void Log(LogLevel level, Exception ex, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                {
                    _logger.Debug(ex, message);
                    break;
                }
                case LogLevel.Information:
                {
                    _logger.Information(ex, message);
                    break;
                }
                case LogLevel.Warning:
                {
                    _logger.Warning(ex, message);
                    break;
                }
                case LogLevel.Error:
                {
                    _logger.Error(ex, message);
                    break;
                }
                case LogLevel.Critical:
                {
                    _logger.Fatal(ex, message);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}