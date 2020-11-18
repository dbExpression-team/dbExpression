using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCoalesceFunctionExpression<TValue, TNullableValue> : CoalesceFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableCoalesceFunctionExpression(IEnumerable<IExpressionElement> expressions) 
            : base(expressions, typeof(TNullableValue))
        {

        }

        protected NullableCoalesceFunctionExpression(IEnumerable<IExpressionElement> expressions, string alias) 
            : base(expressions, typeof(TNullableValue), alias)
        {

        }
        #endregion
    }
}
