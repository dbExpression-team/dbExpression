using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        #region constructors
        protected NullableExpressionMediator()
        { 
        }

        public NullableExpressionMediator(IExpression expression) : this(expression, typeof(TValue))
        {
        }

        protected NullableExpressionMediator(IExpression expression, Type declaredType) : this(expression, declaredType, null)
        {
        }

        protected NullableExpressionMediator(IExpression expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        }
        protected NullableExpressionMediator(IExpression expression, string alias) : base(expression, typeof(TValue), alias)
        {
        }
        #endregion
    }
}
