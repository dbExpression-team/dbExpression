using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CountFunctionExpression<TValue> : CountFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region internals
        private static readonly LiteralExpression<string> STAR = new LiteralExpression<string>("*");
        #endregion

        #region constructors
        protected CountFunctionExpression() : base(STAR, typeof(TValue))
        {

        }

        protected CountFunctionExpression(IExpressionElement expression) : base(expression, typeof(TValue))
        {

        }
        #endregion
    }
}
