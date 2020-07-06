using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMinimumFunctionExpression :
        MinimumFunctionExpression<DateTime>,
        IEquatable<DateTimeMinimumFunctionExpression>
    {
        #region constructors
        public DateTimeMinimumFunctionExpression(ExpressionMediator<DateTime> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DateTimeMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
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
