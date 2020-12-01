using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CeilingFunctionExpression<TValue> : CeilingFunctionExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected CeilingFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
