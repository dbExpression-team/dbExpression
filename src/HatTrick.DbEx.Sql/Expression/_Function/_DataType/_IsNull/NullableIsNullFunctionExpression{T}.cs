using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression<TValue> : NullableIsNullFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected NullableIsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion
    }
}
