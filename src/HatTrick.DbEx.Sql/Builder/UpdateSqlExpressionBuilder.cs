using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        protected UpdateSqlExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
