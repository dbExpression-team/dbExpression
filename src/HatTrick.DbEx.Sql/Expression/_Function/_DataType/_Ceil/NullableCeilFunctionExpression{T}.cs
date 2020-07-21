using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCeilFunctionExpression<TValue> : NullableCeilingFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected NullableCeilFunctionExpression(NullableExpressionMediator<TValue> expression) : base(expression)
        {

        }
        #endregion
    }
}
