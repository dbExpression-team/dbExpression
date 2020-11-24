using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFloorFunctionExpression<TValue, TNullableValue> : FloorFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableFloorFunctionExpression(IExpressionElement expression) 
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
