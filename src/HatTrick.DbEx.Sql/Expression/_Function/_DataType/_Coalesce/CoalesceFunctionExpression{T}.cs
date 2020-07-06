using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression<TValue> : CoalesceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected CoalesceFunctionExpression(IList<NullableExpressionMediator<TValue>> expressions, ExpressionMediator<TValue> notNull) : base(expressions.Concat(new List<ExpressionMediator<TValue>> { notNull }).ToArray())
        {
        }

        protected CoalesceFunctionExpression(IList<ExpressionMediator<string>> expressions, ExpressionMediator<string> notNull) : base(expressions.Concat(new List<ExpressionMediator<string>> { notNull }).ToArray())
        {
        }
        #endregion
    }
}
