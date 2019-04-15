using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForSelectFieldExpression<TValue> : ISupportedForSelectExpression
        //where TValue : IComparable
    {
    }
}
