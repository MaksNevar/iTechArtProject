using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace iTechArt.Common
{
    public sealed class Logger : ILog
    {
        private readonly ILogger _logger;

        private readonly List<Action<string>> _methodList;
        public Logger(ILogger logger)
        {
            _logger = logger;

            _methodList = new List<Action<string>>
            {
                message => _logger.Debug(message),
                message => _logger.Information(message),
                message => _logger.Warning(message),
                message => _logger.Error(message),
                message => _logger.Fatal(message)
            };
        }

        public void Log(LogLevel level, string message)
        {
            _methodList[(int) level].Invoke(message);
        }
    }
}