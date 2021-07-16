using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string _path;

        public LoggerProvider(string path)
        {
            _path = path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(_path);
        }

        public void Dispose()
        {

        }
    }
}