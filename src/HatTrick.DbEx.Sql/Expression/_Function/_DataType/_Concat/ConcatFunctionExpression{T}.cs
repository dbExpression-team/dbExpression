using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConcatFunctionExpression<TValue> : ConcatFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected ConcatFunctionExpression(IList<IExpressionElement> expressions) : base(expressions, typeof(TValue))
        {

        }
        #endregion
    }
}
