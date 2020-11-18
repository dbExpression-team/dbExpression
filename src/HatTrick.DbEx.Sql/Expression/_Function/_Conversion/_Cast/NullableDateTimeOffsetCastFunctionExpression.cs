using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetCastFunctionExpression :
        NullableCastFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetCastFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableDateTimeOffsetCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetCastFunctionExpression obj)
            => obj is NullableDateTimeOffsetCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
