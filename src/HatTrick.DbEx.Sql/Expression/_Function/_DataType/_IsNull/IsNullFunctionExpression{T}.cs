using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression<TValue> : IsNullFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected IsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion
    }
}
