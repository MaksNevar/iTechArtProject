using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public sealed class Logger : IMyLogger
    {
        private readonly ILogger _logger;
        //private readonly string _filePath;
        //private static readonly object Lock = new object();

        public Logger(ILogger logger) => _logger = logger;

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
        //public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        //{
        //    if (formatter == null) return;
        //    lock (Lock)
        //    {
        //        File.AppendAllText(_filePath, formatter(state, exception) + Environment.NewLine);
        //    }
        //}
    }
}