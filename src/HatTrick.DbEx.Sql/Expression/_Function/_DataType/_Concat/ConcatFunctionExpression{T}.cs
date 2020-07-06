using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ConcatFunctionExpression<TValue> : ConcatFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected ConcatFunctionExpression()
        {
        }

        protected ConcatFunctionExpression(params ExpressionMediator<TValue>[] expressions) : base(expressions)
        {
        }
        #endregion
    }
}
