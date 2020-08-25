using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private readonly Func<ISqlDatabaseMetadataProvider, IAssemblyPartAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementBuilderFactory(Func<ISqlDatabaseMetadataProvider, IAssemblyPartAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Builder."); ;
        }

        public DelegateSqlStatementBuilderFactory(Func<ISqlStatementBuilderFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Builder.");

            this.factory = new Func<ISqlDatabaseMetadataProvider, IAssemblyPartAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder>((databaseMetadata, partAppenderFactory, config, expression, appender, parameterBuilder) =>
            {
                var f = factory().CreateSqlStatementBuilder(databaseMetadata, partAppenderFactory, config, expression, appender, parameterBuilder);
                if (f is null)
                    throw new DbExpressionException("Cannot create a Sql Statement Builder: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
        public ISqlStatementBuilder CreateSqlStatementBuilder(ISqlDatabaseMetadataProvider databaseMetadata, IAssemblyPartAppenderFactory partAppenderFactory, SqlStatementAssemblerConfiguration config, QueryExpression expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => factory(databaseMetadata, partAppenderFactory, config, expression, appender, parameterBuilder);
        #endregion
    }
}
