using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IListFromBuilder<T, U, V> : IBuilder<T>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        V From(DBExpressionEntity entity);
        IFromBuilder<T, U, V> Distinct();
    }
}
