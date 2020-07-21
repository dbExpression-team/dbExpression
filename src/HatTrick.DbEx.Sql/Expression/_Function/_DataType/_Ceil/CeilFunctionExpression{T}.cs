using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CeilFunctionExpression<TValue> : CeilingFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected CeilFunctionExpression(ExpressionMediator<TValue> expression) : base(expression)
        {
        }
        #endregion
    }
}
