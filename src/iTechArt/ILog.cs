using System;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public interface ILog
    {
        void Log(LogLevel level, Exception ex, string message);
    }
}