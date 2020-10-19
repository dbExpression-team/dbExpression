using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanMaximumFunctionExpression :
        MaximumFunctionExpression<TimeSpan>,
        IEquatable<TimeSpanMaximumFunctionExpression>
    {
        #region constructors
        public TimeSpanMaximumFunctionExpression(ExpressionMediator<TimeSpan> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new TimeSpanMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(TimeSpanMaximumFunctionExpression obj)
            => obj is TimeSpanMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
