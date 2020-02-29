using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression<TValue> : NullableCoalesceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(Type @type, params ExpressionContainer[] expressions) : base(type, expressions)
        {
        }
        #endregion
    }
}
