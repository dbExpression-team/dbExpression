using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IJoinBuilder<T, U> : IJoinBuilder<U>
        where U : IBuilder<T>
    {
    }
}
