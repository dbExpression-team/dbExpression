using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SumFunctionExpression<TValue> : SumFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected SumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
