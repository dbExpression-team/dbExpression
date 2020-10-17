using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseQueryExpressionConfigurationBuilder : IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseQueryExpressionConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        
        #region methods
        public void UseThisToCreateNewQueryExpressions(IQueryExpressionFactory factory)
        {
            configuration.QueryExpressionFactory = factory;
        }

        public void UseThisToCreateNewQueryExpressions<T>()
            where T : class, IQueryExpressionFactory, new()
        {
            configuration.QueryExpressionFactory = new T();
        }

        public void UseThisToGetAFactoryToCreateNewQueryExpressions<T>(Func<T> factory)
            where T : QueryExpression, new()
        {
            configuration.QueryExpressionFactory = new DelegateQueryExpressionFactory(new Func<Type,QueryExpression>(t => factory()));
        }
        #endregion
    }
}
