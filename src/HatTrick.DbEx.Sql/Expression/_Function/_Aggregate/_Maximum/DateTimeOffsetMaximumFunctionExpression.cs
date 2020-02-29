using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMaximumFunctionExpression :
        MaximumFunctionExpression<DateTimeOffset>,
        IEquatable<DateTimeOffsetMaximumFunctionExpression>
    {
        #region constructors
        public DateTimeOffsetMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new DateTimeOffsetMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
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
