using System;
using System.IO;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace iTechArt.Common
{
<<<<<<< HEAD
    public sealed class Logger : ILog
=======
    public sealed class Logger : IMyLogger
>>>>>>> 575ebb68737b5fc30c9d74a1fb86ecb02121f67b
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger) => _logger = logger;

<<<<<<< HEAD
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
=======
        public void Log(string message)
        {
            _logger.LogInformation(message);
>>>>>>> 575ebb68737b5fc30c9d74a1fb86ecb02121f67b
        }
    }
}
