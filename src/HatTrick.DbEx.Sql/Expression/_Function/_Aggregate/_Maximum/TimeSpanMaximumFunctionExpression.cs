using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanMaximumFunctionExpression :
        MaximumFunctionExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanMaximumFunctionExpression>
    {
        #region constructors
        public TimeSpanMaximumFunctionExpression(TimeSpanElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }
        protected TimeSpanMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
