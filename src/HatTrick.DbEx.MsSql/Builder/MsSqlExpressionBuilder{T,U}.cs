using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder<T,U> : SqlExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        public MsSqlExpressionBuilder(DatabaseConfiguration configuration, ExpressionSet expression) : base(configuration, expression)
        { }
    }
}
