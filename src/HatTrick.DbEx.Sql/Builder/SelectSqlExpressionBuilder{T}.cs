using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectSqlExpressionBuilder<T> : SqlExpressionBuilder<T>,
       IValueContinuationExpressionBuilder<T>,
       IValueListContinuationExpressionBuilder<T>
    {
        #region constructors
        protected SelectSqlExpressionBuilder(DatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
