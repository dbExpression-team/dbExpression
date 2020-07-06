using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableStandardDeviationFunctionExpression<TValue> : NullableStandardDeviationFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableStandardDeviationFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
