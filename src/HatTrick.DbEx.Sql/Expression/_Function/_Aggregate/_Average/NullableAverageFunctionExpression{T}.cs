using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableAverageFunctionExpression<TValue> : NullableAverageFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableAverageFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
