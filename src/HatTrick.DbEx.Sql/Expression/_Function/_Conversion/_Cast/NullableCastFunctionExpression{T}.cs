using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression<TValue> : NullableCastFunctionExpression
         where TValue : IComparable
    {
        #region constructors
        protected NullableCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion
    }
}
