using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder : QueryExpressionBuilder
    {
        #region constructors
        protected SelectQueryExpressionBuilder(DatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
