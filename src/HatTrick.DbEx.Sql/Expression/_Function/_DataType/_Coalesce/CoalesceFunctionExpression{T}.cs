using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression<TValue> : CoalesceFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected CoalesceFunctionExpression(Type @type, IList<ExpressionContainer> expressions, ExpressionContainer notNull) : base(@type, expressions.Concat(new List<ExpressionContainer> { notNull }).ToArray())
        {
        }
        #endregion
    }
}
