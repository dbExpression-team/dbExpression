using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CastFunctionExpression<TValue> : CastFunctionExpression,
        IExpressionElement<TValue>
        where TValue : IComparable
    {
        #region constructors
        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType) 
            : base(expression, convertToDbType, convertToType)
        {

        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType, int? size, int? precision, int? scale, string alias) 
            : base(expression, convertToDbType, convertToType, size, precision, scale, alias)
        {

        }
        #endregion
    }
}
