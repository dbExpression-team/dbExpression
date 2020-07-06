using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression<TValue> : IsNullFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected IsNullFunctionExpression(NullableExpressionMediator<TValue> expression, ExpressionMediator<TValue> value) : base(expression, value)
        {
        }

        protected IsNullFunctionExpression(ExpressionMediator<string> expression, ExpressionMediator<string> value) : base(expression, value)
        {
        }
        #endregion
    }
}
