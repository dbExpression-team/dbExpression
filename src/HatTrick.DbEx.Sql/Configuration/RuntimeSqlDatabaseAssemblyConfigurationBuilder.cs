using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration.Syntax;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseAssemblyConfigurationBuilder : IRuntimeSqlDatabaseAssemblyConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseAssemblyConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder ConfigureAttributesOfAssemblingSqlStatements(Action<SqlStatementAssemblerConfiguration> config)
        {
            config(configuration.AssemblerConfiguration);
            return this;
        }

        #region element appender
        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingQueryExpressionPartsToTheSqlStatement(IExpressionElementAppenderFactory factory)
        {
            configuration.AssemblyPartAppenderFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingSqlStatements<T>()
            where T : class, IExpressionElementAppenderFactory, new()
        {
            configuration.AssemblyPartAppenderFactory = new T();
            if (configuration.AssemblyPartAppenderFactory is ExpressionElementAppenderFactory defaultFactory)
                defaultFactory.RegisterDefaultElementAppenders();
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateAppendersForWritingSqlStatements<T>(Func<T> factory)
            where T : IExpressionElementAppenderFactory, new()
        {
            configuration.AssemblyPartAppenderFactory = new DelegateExpressionElementAppenderFactory(new Func<IExpressionElementAppenderFactory>(() => factory()));
            return this;
        }
        #endregion

        #region appender factory
        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateWritersForCreatingSqlStatements(IAppenderFactory factory)
        {
            configuration.AppenderFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateWritersForCreatingSqlStatements<T>()
            where T : class, IAppenderFactory, new()
        {
            configuration.AppenderFactory = new T();
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisAccessorToCreateAWriterForCreatingASqlStatement(Func<IAppender> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingNewWritersForCreatingSqlStatements(Func<IAppenderFactory> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
            return this;
        }
        #endregion

        #region statement builder
        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateNewSqlStatementBuilders(ISqlStatementBuilderFactory factory)
        {
            configuration.StatementBuilderFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateNewSqlStatementBuilders<T>()
            where T : class, ISqlStatementBuilderFactory, new()
        {
            configuration.StatementBuilderFactory = new T();
            if (configuration.StatementBuilderFactory is SqlStatementBuilderFactory defaultFactory)
                defaultFactory.RegisterDefaultStatementAssemblers();
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingNewSqlStatementBuilders(Func<ISqlStatementBuilderFactory> factory)
        {
            configuration.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
            return this;
        }
        #endregion

        #region parameter builder
        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters(ISqlParameterBuilderFactory factory)
        {
            configuration.ParameterBuilderFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters<T>()
            where T : class, ISqlParameterBuilderFactory, new()
        {
            configuration.ParameterBuilderFactory = new T();
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToCreateSqlParameters(Func<ISqlParameterBuilder> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
            return this;
        }

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder UseThisToGetAFactoryForCreatingSqlParameters(Func<ISqlParameterBuilderFactory> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
            return this;
        }
        #endregion
        #endregion
    }
}
