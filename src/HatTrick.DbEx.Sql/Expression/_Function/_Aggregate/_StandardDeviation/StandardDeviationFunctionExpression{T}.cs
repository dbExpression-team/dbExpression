using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class StandardDeviationFunctionExpression<TValue> : StandardDeviationFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected StandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct) : base(expression, typeof(TValue), isDistinct)
        {

        }

        protected StandardDeviationFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, typeof(TValue), isDistinct, alias)
        {

        }
        #endregion
    }
}
