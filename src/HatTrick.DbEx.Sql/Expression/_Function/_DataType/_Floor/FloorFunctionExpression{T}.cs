using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FloorFunctionExpression<TValue> : FloorFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected FloorFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
