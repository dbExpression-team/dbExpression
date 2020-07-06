using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableSumFunctionExpression<TValue> : NullableSumFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected NullableSumFunctionExpression(ExpressionMediator expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
