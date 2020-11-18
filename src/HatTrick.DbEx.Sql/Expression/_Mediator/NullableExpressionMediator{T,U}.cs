using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableExpressionMediator<TValue,TNullableValue> : ExpressionMediator,
        IExpressionElement<TValue, TNullableValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        {
        }

        protected NullableExpressionMediator(IExpressionElement expression, Type declaredType) : this(expression, declaredType, null)
        {
        }

        protected NullableExpressionMediator(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        } 
        #endregion
    }
}
