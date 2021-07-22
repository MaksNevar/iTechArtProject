using Serilog.Events;

namespace iTechArt.Common
{
    public enum LogLevel
    {
        Debug = LogEventLevel.Debug,
        Information = LogEventLevel.Information,
        Warning = LogEventLevel.Warning,
        Error = LogEventLevel.Error,
        Fatal = LogEventLevel.Fatal
    }
}