using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMaximumFunctionExpression :
        NullableMaximumFunctionExpression<TimeSpan>,
        IEquatable<NullableTimeSpanMaximumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMaximumFunctionExpression(NullableExpressionMediator<TimeSpan> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanMaximumFunctionExpression obj)
            => obj is NullableTimeSpanMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
