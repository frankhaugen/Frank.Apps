using System;
using Frank.Apps.Loggers.LoggingProviders.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.Loggers.LoggingProviders.Extensions;

public static class LoggerBuilderExtensions
{
    public static ILoggingBuilder AddEntityFrameworkLogger<TContext>(this ILoggingBuilder builder, Action<EntityFrameworkLoggerConfiguration> configuration) where TContext : DbContext
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Services.Configure(configuration);
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, EntityFrameworkLoggerProvider<TContext>>());
        builder.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
        return builder;
    }
}