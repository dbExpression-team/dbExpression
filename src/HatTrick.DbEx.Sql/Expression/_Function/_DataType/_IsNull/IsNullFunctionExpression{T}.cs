using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class IsNullFunctionExpression<TValue> : IsNullFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value) : base(expression, typeof(TValue), value)
        {

        }

        protected IsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, typeof(TValue), value, alias)
        {

        }
        #endregion
    }
}
