using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlParameterBuilderFactoryConfigurationBuilder : ISqlParameterBuilderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public SqlParameterBuilderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlParameterBuilderFactory factory)
        {
            configuration.ParameterBuilderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>()
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new()
            => Use<TSqlParameterBuilderFactory>(null);

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>(Action<TSqlParameterBuilderFactory> configureFactory)
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new()
        {
            if (!(configuration.ParameterBuilderFactory is TSqlParameterBuilderFactory))
                configuration.ParameterBuilderFactory = new TSqlParameterBuilderFactory();
            configureFactory?.Invoke(configuration.ParameterBuilderFactory as TSqlParameterBuilderFactory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<ISqlParameterBuilder> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory ?? throw new ArgumentNullException($"{nameof(factory)} is required."));
            return caller;
        }
    }
}
