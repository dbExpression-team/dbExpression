using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanMinimumFunctionExpression :
        MinimumFunctionExpression<TimeSpan>,
        IEquatable<TimeSpanMinimumFunctionExpression>
    {
        #region constructors
        public TimeSpanMinimumFunctionExpression(ExpressionMediator<TimeSpan> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new TimeSpanMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(TimeSpanMinimumFunctionExpression obj)
            => obj is TimeSpanMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
