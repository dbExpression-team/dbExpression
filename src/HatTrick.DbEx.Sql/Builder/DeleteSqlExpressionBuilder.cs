using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class DeleteSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        protected DeleteSqlExpressionBuilder(DatabaseConfiguration configuration, DeleteQueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
