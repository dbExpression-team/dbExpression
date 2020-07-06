using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression<TValue> : NullableCastFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected NullableCastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion
    }
}
