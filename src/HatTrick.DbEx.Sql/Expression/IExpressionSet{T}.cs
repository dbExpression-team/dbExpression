using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionSet<T> : IExpressionSet
        where T : class, IExpression
    {
        IEnumerable<T> Expressions { get; }
    }
}
