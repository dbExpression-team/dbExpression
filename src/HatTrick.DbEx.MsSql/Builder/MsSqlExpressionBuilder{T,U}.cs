using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder<T,U> : SqlExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
    }
}
