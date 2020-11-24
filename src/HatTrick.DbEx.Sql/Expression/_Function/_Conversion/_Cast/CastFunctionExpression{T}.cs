using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CastFunctionExpression<TValue> : CastFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType) 
            : base(expression, convertToDbType, typeof(TValue))
        {

        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int size)
            : base(expression, convertToDbType, typeof(TValue), size)
        {

        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int precision, int? scale)
            : base(expression, convertToDbType, typeof(TValue), precision, scale)
        {

        }
        #endregion
    }
}
