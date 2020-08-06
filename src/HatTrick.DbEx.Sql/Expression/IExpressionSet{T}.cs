using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionSet<T> : IExpressionSet
        where T : class, IExpression
    {
        IList<T> Expressions { get; }
    }
}
