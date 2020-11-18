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
        public DateTimeMaximumFunctionExpression(DateTimeElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DateTimeMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
