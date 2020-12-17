using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class TimeSpanIsNullFunctionExpression :
        IsNullFunctionExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanIsNullFunctionExpression>
    {
        #region constructors
        public TimeSpanIsNullFunctionExpression(AnyTimeSpanElement expression, TimeSpanElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(TimeSpanIsNullFunctionExpression obj)
            => obj is TimeSpanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
