using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlExpressionBuilder<T> : SqlExpressionBuilder,
        IValueContinuationExpressionBuilder<T>,
        IValueListContinuationExpressionBuilder<T>
    {
        #region constructors
        public SqlExpressionBuilder(DatabaseConfiguration configuration, ExpressionSet expression) : base(configuration, expression)
        { }
        #endregion
    }
}
