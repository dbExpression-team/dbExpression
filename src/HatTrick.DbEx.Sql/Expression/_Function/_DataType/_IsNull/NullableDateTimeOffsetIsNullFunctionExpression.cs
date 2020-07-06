using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetIsNullFunctionExpression :
        NullableIsNullFunctionExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetIsNullFunctionExpression>
    {
        #region constructors
        public NullableDateTimeOffsetIsNullFunctionExpression(NullableExpressionMediator<DateTimeOffset> expression, ExpressionMediator<DateTimeOffset> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetIsNullFunctionExpression obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
