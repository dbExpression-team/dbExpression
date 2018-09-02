using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder<T, U, V> : SqlExpressionBuilder<T, U, V>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        {
        }
    }
}
