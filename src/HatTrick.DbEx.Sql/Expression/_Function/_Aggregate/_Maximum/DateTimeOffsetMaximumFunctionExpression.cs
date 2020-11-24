using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMaximumFunctionExpression :
        MaximumFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement,
        IEquatable<DateTimeOffsetMaximumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMaximumFunctionExpression(DateTimeOffsetElement expression) : base(expression)
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

        #region distinct
        public DateTimeOffsetMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetMaximumFunctionExpression obj)
            => obj is DateTimeOffsetMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
