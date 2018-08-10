using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IJoinBuilder<T>
        where T : IBuilder
    {
        T On(DBFilterExpression expression);
    }
}
