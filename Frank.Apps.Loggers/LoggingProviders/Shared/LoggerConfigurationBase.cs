using Microsoft.Extensions.Logging;

namespace Frank.Apps.Loggers.LoggingProviders.Shared;

public abstract class LoggerConfigurationBase
{
    public LogLevel LogLevel { get; set; } = LogLevel.Information;
}