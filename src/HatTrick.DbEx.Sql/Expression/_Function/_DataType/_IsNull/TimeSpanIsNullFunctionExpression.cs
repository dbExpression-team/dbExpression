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

        protected TimeSpanIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public TimeSpanElement As(string alias)
            => new TimeSpanIsNullFunctionExpression(base.Expression, base.Value, alias);
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
