using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class MsSqlBuilder<T,U> : SqlBuilder<T,U>
        where U : class, IContinuationBuilder<T>
    {
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        { }
    }
}
