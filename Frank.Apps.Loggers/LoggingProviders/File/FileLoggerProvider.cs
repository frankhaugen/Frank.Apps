using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.Loggers.LoggingProviders.File;

public sealed class FileLoggerProvider : ILoggerProvider
{
    private readonly ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();
    private readonly FileLoggerConfiguration _configuration;

    public FileLoggerProvider(FileLoggerConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _configuration));
    }

    public void Dispose()
    {
    }
}