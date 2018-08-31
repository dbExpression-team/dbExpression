using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder<T> : SqlExpressionBuilder<T>,
        IValueContinuationExpressionBuilder<T>,
        IValueListContinuationExpressionBuilder<T>
    {
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
    }
}