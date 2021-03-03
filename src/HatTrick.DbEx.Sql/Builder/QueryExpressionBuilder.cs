using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class QueryExpressionBuilder :
        ITerminationExpressionBuilder,
        IQueryExpressionProvider,
        IRuntimeSqlDatabaseConfigurationProvider
    {
        #region internals
        protected RuntimeSqlDatabaseConfiguration Configuration { get; private set; }
        private readonly QueryExpression expression;
        #endregion

        #region interface
        QueryExpression IQueryExpressionProvider.Expression => expression;
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabaseConfigurationProvider.Configuration => Configuration;
        #endregion

        #region constructors
        protected QueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, QueryExpression expression)
        {
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion
    }
}
