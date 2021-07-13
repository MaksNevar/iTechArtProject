using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public sealed class Logger : ILogger
    {
        private readonly string _filePath;
        private static readonly object Lock = new object();

        public Logger(string path) => _filePath = path;

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter == null) return;
            lock (Lock)
            {
                File.AppendAllText(_filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}