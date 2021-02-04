using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IAppenderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(IAppenderFactory factory);

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>()
            where TAppenderFactory : class, IAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        /// <param name="configureFactory">Configure the <typeparamref name="TAppenderFactory"/> factory.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>(Action<TAppenderFactory> configureFactory)
            where TAppenderFactory : class, IAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<IAppender> factory);

        /// <summary>
        /// Use the default factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory();
    }
}
