using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanIsNullFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanIsNullFunctionExpression(AnyTimeSpanElement expression, NullableTimeSpanElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableTimeSpanElement As(string alias)
            => new NullableTimeSpanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanIsNullFunctionExpression obj)
            => obj is NullableTimeSpanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
