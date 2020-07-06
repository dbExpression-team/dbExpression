using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SumFunctionExpression<TValue> : SumFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected SumFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
