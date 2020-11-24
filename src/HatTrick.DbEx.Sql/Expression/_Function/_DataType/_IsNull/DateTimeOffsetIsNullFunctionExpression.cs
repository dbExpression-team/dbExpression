using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetIsNullFunctionExpression :
        IsNullFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetIsNullFunctionExpression(AnyDateTimeOffsetElement expression, DateTimeOffsetElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public DateTimeOffsetElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetIsNullFunctionExpression obj)
            => obj is DateTimeOffsetIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
