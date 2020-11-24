using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMaximumFunctionExpression :
        NullableMaximumFunctionExpression<DateTimeOffset,DateTimeOffset?>,
        NullableDateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<NullableDateTimeOffsetMaximumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetMaximumFunctionExpression(NullableDateTimeOffsetElement expression) 
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
        public NullableDateTimeOffsetMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetMaximumFunctionExpression obj)
            => obj is NullableDateTimeOffsetMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
