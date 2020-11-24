using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableAverageFunctionExpression<TValue,TNullableValue> : AverageFunctionExpression,
        IExpressionElement<TValue,TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableAverageFunctionExpression(IExpressionElement expression) 
            : base(expression, typeof(TNullableValue))
        {

        }
        #endregion
    }
}
