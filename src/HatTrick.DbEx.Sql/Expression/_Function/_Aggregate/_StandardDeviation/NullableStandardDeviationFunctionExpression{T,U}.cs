using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableStandardDeviationFunctionExpression<TValue, TNullableValue> : StandardDeviationFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct) 
            : base(expression, typeof(TNullableValue), isDistinct)
        {

        }

        protected NullableStandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, typeof(TNullableValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
