using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMinimumFunctionExpression :
        MinimumFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
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
