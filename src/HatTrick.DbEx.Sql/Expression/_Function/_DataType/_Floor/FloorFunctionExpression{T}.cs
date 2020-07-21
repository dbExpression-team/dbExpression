using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression<TValue> : FloorFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected FloorFunctionExpression(ExpressionMediator<TValue> expression) : base(expression)
        {
        }
        #endregion
    }
}
