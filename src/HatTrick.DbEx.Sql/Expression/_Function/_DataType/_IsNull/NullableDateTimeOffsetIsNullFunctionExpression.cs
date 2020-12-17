using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullableDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetIsNullFunctionExpression(AnyDateTimeOffsetElement expression, NullableDateTimeOffsetElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableDateTimeOffsetElement As(string alias)
            => new NullableDateTimeOffsetSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetIsNullFunctionExpression obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
