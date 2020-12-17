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
        public TimeSpanMaximumFunctionExpression(TimeSpanElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public TimeSpanMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
