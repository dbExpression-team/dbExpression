using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeIsNullFunctionExpression :
        IsNullFunctionExpression<DateTime>,
        DateTimeElement,
        AnyDateTimeElement,
        IEquatable<DateTimeIsNullFunctionExpression>
    {
        #region constructors
        public DateTimeIsNullFunctionExpression(AnyDateTimeElement expression, DateTimeElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(DateTimeIsNullFunctionExpression obj)
            => obj is DateTimeIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
