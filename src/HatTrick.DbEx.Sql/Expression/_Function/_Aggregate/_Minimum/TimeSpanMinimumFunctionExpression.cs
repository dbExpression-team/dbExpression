using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanMinimumFunctionExpression :
        MinimumFunctionExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanMinimumFunctionExpression>
    {
        #region constructors
        public TimeSpanMinimumFunctionExpression(TimeSpanElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected TimeSpanMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
