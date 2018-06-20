using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IJoinBuilder<T, U> : IJoinBuilder<U>
        where U : IBuilder<T>
    {
    }
}
