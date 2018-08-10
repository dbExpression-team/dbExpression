using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Builder
{
    public class MsSqlBuilder<T,U> : SqlBuilder<T,U>
        where U : class, IContinuationBuilder<T>
    {
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
    }
}
