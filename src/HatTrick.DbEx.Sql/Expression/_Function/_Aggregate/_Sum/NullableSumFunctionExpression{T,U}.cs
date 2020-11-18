using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression<TValue, TNullableValue> : SumFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableSumFunctionExpression(IExpressionElement expression, Type declaredType, bool isDistinct) 
            : base(expression, declaredType, isDistinct)
        {

        }

        protected NullableSumFunctionExpression(IExpressionElement expression, Type declaredType, bool isDistinct, string alias) 
            : base(expression, declaredType, isDistinct, alias)
        {

        }
        #endregion
    }
}
