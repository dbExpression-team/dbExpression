using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMinimumFunctionExpression :
        NullableMinimumFunctionExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetMinimumFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetMinimumFunctionExpression obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
