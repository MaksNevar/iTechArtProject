using System;

namespace iTechArt.Common
{
    public interface ILog
    {
        void Log(LogLevel level, string message);

        void Log(LogLevel level, Exception exception, string message);
    }
}