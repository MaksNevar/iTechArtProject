using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
                                        string filePath)
        {
            //factory.AddProvider(new LoggerProvider(filePath));

            return factory;
        }
    }
}