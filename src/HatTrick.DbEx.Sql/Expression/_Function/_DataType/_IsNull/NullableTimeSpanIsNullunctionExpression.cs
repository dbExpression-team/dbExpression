using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<TimeSpan>,
        IEquatable<NullableTimeSpanIsNullFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanIsNullFunctionExpression(NullableExpressionMediator<TimeSpan> expression, ExpressionMediator<TimeSpan> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanIsNullFunctionExpression obj)
            => obj is NullableTimeSpanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
