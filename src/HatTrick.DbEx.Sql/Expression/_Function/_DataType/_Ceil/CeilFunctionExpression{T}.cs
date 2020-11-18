using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CeilFunctionExpression<TValue> : CeilingFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected CeilFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }

        protected CeilFunctionExpression(IExpressionElement expression, string alias) : base(expression, typeof(TValue), alias)
        {

        }
        #endregion
    }
}
