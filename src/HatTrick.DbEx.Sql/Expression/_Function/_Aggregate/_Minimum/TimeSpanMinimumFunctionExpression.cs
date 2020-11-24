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
        public TimeSpanMinimumFunctionExpression(TimeSpanElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public TimeSpanMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
