using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlInsertBuilder<T> : SqlInsertExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public MsSqlInsertBuilder(ExpressionSet expression) : base(expression)
        { }
    }
}