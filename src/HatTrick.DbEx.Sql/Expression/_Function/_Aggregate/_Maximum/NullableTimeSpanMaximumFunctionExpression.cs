using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMaximumFunctionExpression :
        NullableMaximumFunctionExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanMaximumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMaximumFunctionExpression(NullableTimeSpanElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableTimeSpanElement As(string alias)
            => new NullableTimeSpanSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableTimeSpanMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
