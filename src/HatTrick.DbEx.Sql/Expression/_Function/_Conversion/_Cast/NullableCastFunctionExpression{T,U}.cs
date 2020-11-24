using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableCastFunctionExpression<TValue,TNullableValue> : CastFunctionExpression,
        IExpressionElement<TValue, TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(TNullableValue))
        {

        }

        protected NullableCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int precision, int? scale)
            : base(expression, convertToDbType, typeof(TNullableValue), precision, scale)
        {

        }
        #endregion
    }
}
