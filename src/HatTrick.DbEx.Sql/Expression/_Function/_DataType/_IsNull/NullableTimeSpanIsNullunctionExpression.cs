using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanIsNullFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanIsNullFunctionExpression(AnyTimeSpanElement expression, NullTimeSpanElement value)
            : base(expression, value)
        {

        }

        protected NullableTimeSpanIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullTimeSpanElement As(string alias)
            => new NullableTimeSpanIsNullFunctionExpression(base.Expression, base.Value, alias);
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
