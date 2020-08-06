using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class QueryExpressionBuilder<T> : QueryExpressionBuilder,
        IValueContinuationExpressionBuilder<T>,
        IValueListContinuationExpressionBuilder<T>
    {
        #region constructors
        protected QueryExpressionBuilder(DatabaseConfiguration configuration, QueryExpression expression) : base(configuration, expression)
        { }
        #endregion
    }
}
