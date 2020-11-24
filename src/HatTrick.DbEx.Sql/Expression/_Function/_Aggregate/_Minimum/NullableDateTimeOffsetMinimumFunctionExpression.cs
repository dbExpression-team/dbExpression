using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullableDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetMinimumFunctionExpression(NullableDateTimeOffsetElement expression) 
            : base(expression)
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

        #region distinct
        public NullableDateTimeOffsetMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetMinimumFunctionExpression obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
