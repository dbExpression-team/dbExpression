using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanMinimumFunctionExpression :
        NullableMinimumFunctionExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        AnyTimeSpanElement, 
        IEquatable<NullableTimeSpanMinimumFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanMinimumFunctionExpression(NullableTimeSpanElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableTimeSpanElement As(string alias)
            => new NullableTimeSpanSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableTimeSpanMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
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
