using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IJoinBuilder<T>
        where T : IBuilder
    {
        T On(DBFilterExpression expression);
    }
}
