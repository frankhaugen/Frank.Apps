using System;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.Loggers.LoggingProviders.EntityFramework;

public abstract class EntityFrameworkLoggerProviderBase : ILoggerProvider
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public abstract ILogger CreateLogger(string categoryName);
}