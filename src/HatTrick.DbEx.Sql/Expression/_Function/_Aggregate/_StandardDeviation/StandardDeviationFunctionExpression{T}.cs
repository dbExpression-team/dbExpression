using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class StandardDeviationFunctionExpression<TValue> : StandardDeviationFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected StandardDeviationFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
