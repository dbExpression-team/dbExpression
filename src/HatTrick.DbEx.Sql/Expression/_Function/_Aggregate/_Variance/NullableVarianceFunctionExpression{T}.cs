using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableVarianceFunctionExpression<TValue> : NullableVarianceFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected NullableVarianceFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
