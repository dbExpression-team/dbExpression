using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetCastFunctionExpression :
        CastFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetCastFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(DateTimeOffset))
        {

        }

        protected DateTimeOffsetCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(DateTimeOffset), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
            => new DateTimeOffsetCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetCastFunctionExpression obj)
            => obj is DateTimeOffsetCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
