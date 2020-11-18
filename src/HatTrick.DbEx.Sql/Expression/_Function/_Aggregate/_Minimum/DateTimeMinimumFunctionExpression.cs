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
        public DateTimeMinimumFunctionExpression(DateTimeElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected DateTimeMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public DateTimeElement As(string alias)
            => new DateTimeMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
