using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private readonly Func<ISqlDatabaseMetadataProvider, IExpressionElementAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementBuilderFactory(Func<ISqlDatabaseMetadataProvider, IExpressionElementAppenderFactory, SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Statement Builder.");
        }
        #endregion

        #region methods
        public ISqlStatementBuilder CreateSqlStatementBuilder(
            ISqlDatabaseMetadataProvider databaseMetadata, 
            IExpressionElementAppenderFactory partAppenderFactory, 
            SqlStatementAssemblerConfiguration config, 
            QueryExpression expression, 
            IAppender appender, 
            ISqlParameterBuilder parameterBuilder
        )
            => factory(databaseMetadata, partAppenderFactory, config, expression, appender, parameterBuilder) ?? 
                throw new DbExpressionConfigurationException("Could not resolve a statement builder, please ensure an statement builder factory has been properly registered.");
        #endregion
    }
}
