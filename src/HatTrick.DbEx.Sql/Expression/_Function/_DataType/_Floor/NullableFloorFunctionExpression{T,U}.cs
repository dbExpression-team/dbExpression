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

        protected NullableFloorFunctionExpression(IExpressionElement expression, string alias) 
            : base(expression, typeof(TNullableValue), alias)
        {

        }
        #endregion
    }
}
