using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public sealed class Logger : IMyLogger
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger) => _logger = logger;

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
