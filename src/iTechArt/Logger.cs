using System;
using System.Collections.Generic;
using ILogger = Serilog.ILogger;

namespace iTechArt.Common
{
    public sealed class Logger : ILog
    {
        private readonly List<Action<string>> _methodList;
        public Logger(ILogger logger)
        {
            _methodList = new List<Action<string>>
            {
                logger.Debug,
                logger.Information,
                logger.Warning,
                logger.Error,
                logger.Fatal
            };
        }

        public void Log(LogLevel level, string message)
        {
            _methodList[(int) level].Invoke(message);
        }
    }
}