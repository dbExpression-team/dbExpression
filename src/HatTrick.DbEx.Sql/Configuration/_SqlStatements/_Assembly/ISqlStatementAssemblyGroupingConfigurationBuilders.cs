using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementAssemblyGroupingConfigurationBuilders : ISqlStatementConfigurationBuilderExecutionGrouping
    {
        /// <summary>
        /// Configure the factory used for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        IAppenderFactoryConfigurationBuilder StatementAppender { get; }

        /// <summary>
        /// Configure the factory used for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        IExpressionElementAppenderFactoryConfigurationBuilder ElementAppender { get; }

        /// <summary>
        /// Configure the factory used for creating the parameters used in a parameterized sql statement.
        /// </summary>
        ISqlParameterBuilderFactoryConfigurationBuilder ParameterBuilder { get; }

        /// <summary>
        /// Configure the factory used to create the builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementBuilderFactoryConfigurationBuilder StatementBuilder { get; }

        /// <summary>
        /// Configure the settings used to construct a sql statement.
        /// </summary>
        /// <param name="configure">Configure the settings used while constructing sql statements.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> configure);
    }
}
