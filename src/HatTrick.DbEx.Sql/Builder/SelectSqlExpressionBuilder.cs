using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        protected SelectSqlExpressionBuilder(DatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
