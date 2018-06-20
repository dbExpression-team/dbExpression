using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class MsSqlBuilder<T, U, V> : SqlBuilder<T, U, V>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        public MsSqlBuilder(DBExpressionSet expression) : base(expression)
        {
        }
    }
}
