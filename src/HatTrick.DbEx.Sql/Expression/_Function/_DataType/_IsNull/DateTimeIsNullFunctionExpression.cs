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

        protected DateTimeIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeIsNullFunctionExpression(base.Expression, base.Value, alias);
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
