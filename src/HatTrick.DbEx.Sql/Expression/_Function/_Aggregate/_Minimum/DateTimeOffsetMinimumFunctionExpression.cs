using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMinimumFunctionExpression :
        MinimumFunctionExpression<DateTimeOffset>,
        DateTimeOffsetElement,
        AnyDateTimeOffsetElement, 
        IEquatable<DateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMinimumFunctionExpression(DateTimeOffsetElement expression) : base(expression)
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
        public DateTimeOffsetMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeOffsetMinimumFunctionExpression obj)
            => obj is DateTimeOffsetMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeOffsetMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
