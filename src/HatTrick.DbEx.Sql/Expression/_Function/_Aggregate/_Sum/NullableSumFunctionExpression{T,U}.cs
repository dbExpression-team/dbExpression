using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression<TValue, TNullableValue> : SumFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableSumFunctionExpression(IExpressionElement expression) 
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
