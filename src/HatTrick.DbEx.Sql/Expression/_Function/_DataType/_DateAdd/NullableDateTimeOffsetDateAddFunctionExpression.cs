using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetDateAddFunctionExpression :
        NullableDateAddFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullableDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetDateAddFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, NullableDateTimeOffsetElement expression)
            : base(datePart, value, expression)
        {

        }

        public NullableDateTimeOffsetDateAddFunctionExpression(DatePartsExpression datePart, AnyInt32Element value, DateTimeOffsetElement expression)
            : base(datePart, value, expression)
        {

        }
        #endregion

        #region as
        public NullableDateTimeOffsetElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetDateAddFunctionExpression obj)
            => obj is NullableDateTimeOffsetDateAddFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetDateAddFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
