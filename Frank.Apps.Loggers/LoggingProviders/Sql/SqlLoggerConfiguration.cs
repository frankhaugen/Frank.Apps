using Frank.Apps.Loggers.LoggingProviders.Shared;

namespace Frank.Apps.Loggers.LoggingProviders.Sql;

public class SqlLoggerConfiguration : LoggerConfigurationBase
{
    public string ConnectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=LoggingDatabase;Trusted_Connection=True;";
}