using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementBuilderFactoryConfigurationBuilder : ISqlStatementBuilderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public SqlStatementBuilderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlStatementBuilderFactory factory)
        {
            configuration.StatementBuilderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlStatementBuilderFactory>()
            where TSqlStatementBuilderFactory : class, ISqlStatementBuilderFactory, new()
        {
            configuration.StatementBuilderFactory = new TSqlStatementBuilderFactory();
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<ISqlDatabaseMetadataProvider, IExpressionElementAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            configuration.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
            return caller;
        }
    }
}
