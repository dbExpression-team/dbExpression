using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IFromBuilder<T, U, V> : IBuilder<T>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        V From(DBExpressionEntity entity);
    }
}
