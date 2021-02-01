using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IExpressionElementAppenderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating appenders for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(IExpressionElementAppenderFactory factory);

        /// <summary>
        /// Use a custom factory for creating appenders for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>()
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating appenders for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        /// <param name="configureFactory">Configure the <typeparamref name="TExpressionElementAppenderFactory"/> factory.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>(Action<TExpressionElementAppenderFactory> configureFactory)
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating appenders for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IExpressionElementAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<Type, IExpressionElementAppender> factory);

        /// <summary>
        /// Use the default factory for creating appenders for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory();
    }
}
