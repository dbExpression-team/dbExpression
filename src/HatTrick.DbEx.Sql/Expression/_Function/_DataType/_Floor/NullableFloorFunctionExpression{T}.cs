using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFloorFunctionExpression<TValue> : NullableFloorFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableFloorFunctionExpression(NullableExpressionMediator<TValue> expression) : base(expression)
        {

        }
        #endregion
    }
}
