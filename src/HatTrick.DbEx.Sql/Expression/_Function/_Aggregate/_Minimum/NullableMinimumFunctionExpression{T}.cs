using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMinimumFunctionExpression<TValue> : NullableMinimumFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableMinimumFunctionExpression(NullableExpressionMediator<TValue> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
