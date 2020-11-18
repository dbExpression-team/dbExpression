using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConcatFunctionExpression<TValue> : ConcatFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected ConcatFunctionExpression(IList<AnyStringElement> expressions) : base(expressions, typeof(TValue))
        {

        }

        protected ConcatFunctionExpression(IList<AnyStringElement> expressions, string alias) : base(expressions, typeof(TValue), alias)
        {

        }
        #endregion
    }
}
