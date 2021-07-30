using System;

namespace iTechArt.Common
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILog logger, string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public static void LogDebug(this ILog logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Debug, exception, message);
        }

        public static void LogInformation(this ILog logger, string message)
        {
            logger.Log(LogLevel.Information, message);
        }

        public static void LogInformation(this ILog logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Information, exception, message);
        }

        public static void LogWarning(this ILog logger, string message)
        {
            logger.Log(LogLevel.Warning, message);
        }

        public static void LogWarning(this ILog logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Warning, exception, message);
        }

        public static void LogError(this ILog logger, string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        public static void LogError(this ILog logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Error, exception, message);
        }

        public static void LogFatal(this ILog logger, string message)
        {
            logger.Log(LogLevel.Fatal, message);
        }

        public static void LogFatal(this ILog logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Fatal, exception, message);
        }
    }
}