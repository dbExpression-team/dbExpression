using HTL.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IFromBuilder<T, U, V> : IBuilder<T>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        V From(DBExpressionEntity entity);
    }
}
