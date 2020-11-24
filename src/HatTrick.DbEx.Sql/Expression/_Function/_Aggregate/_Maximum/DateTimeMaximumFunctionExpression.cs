using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMaximumFunctionExpression :
        MaximumFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeMaximumFunctionExpression>
    {
        #region constructors
        public DateTimeMaximumFunctionExpression(DateTimeElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public DateTimeMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeMaximumFunctionExpression obj)
            => obj is DateTimeMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
