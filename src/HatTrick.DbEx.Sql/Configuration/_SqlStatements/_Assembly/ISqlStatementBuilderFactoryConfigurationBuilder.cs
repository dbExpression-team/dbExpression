using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementBuilderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlStatementBuilderFactory factory);

        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlStatementBuilderFactory>()
            where TSqlStatementBuilderFactory : class, ISqlStatementBuilderFactory, new();

        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementBuilder"/> given a plethora of other things.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<ISqlDatabaseMetadataProvider, IExpressionElementAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory);
    }
}
