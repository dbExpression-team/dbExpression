using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanCastFunctionExpression :
        NullableCastFunctionExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanCastFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableTimeSpanElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanCastFunctionExpression obj)
            => obj is NullableTimeSpanCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
