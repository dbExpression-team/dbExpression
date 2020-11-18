using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class VarianceFunctionExpression<TValue> : VarianceFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected VarianceFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected VarianceFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
