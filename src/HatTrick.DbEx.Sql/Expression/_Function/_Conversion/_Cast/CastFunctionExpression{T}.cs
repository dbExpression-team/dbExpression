using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CastFunctionExpression<TValue> : CastFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected CastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }

        #endregion
    }
}
