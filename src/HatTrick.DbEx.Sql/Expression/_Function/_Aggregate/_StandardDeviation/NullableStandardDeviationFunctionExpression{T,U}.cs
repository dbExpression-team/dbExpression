using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableStandardDeviationFunctionExpression<TValue, TNullableValue> : StandardDeviationFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableStandardDeviationFunctionExpression(IExpressionElement expression) 
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
