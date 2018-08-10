using System.Collections.Generic;

namespace HTL.DbEx.Sql.Expression
{
    public interface IDBExpressionSet<T> : IDBExpressionSet
        where T : class, IDBExpression
    {
        IList<T> Expressions { get; }
    }
}
