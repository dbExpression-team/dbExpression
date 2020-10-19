using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMinimumFunctionExpression :
        NullableMinimumFunctionExpression<TimeSpan>,
        IEquatable<NullableTimeSpanMinimumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMinimumFunctionExpression(NullableExpressionMediator<TimeSpan> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanMinimumFunctionExpression obj)
            => obj is NullableTimeSpanMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
