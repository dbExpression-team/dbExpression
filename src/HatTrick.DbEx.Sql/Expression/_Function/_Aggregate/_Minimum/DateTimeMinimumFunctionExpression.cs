using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMinimumFunctionExpression :
        MinimumFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeMinimumFunctionExpression>
    {
        #region constructors
        public DateTimeMinimumFunctionExpression(DateTimeElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public DateTimeMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(DateTimeMinimumFunctionExpression obj)
            => obj is DateTimeMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
