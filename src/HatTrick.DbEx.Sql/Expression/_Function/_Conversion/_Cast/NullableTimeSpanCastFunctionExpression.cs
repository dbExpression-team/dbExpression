using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableTimeSpanCastFunctionExpression :
        NullableCastFunctionExpression<TimeSpan>,
        IEquatable<NullableTimeSpanCastFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanCastFunctionExpression(ExpressionMediator expression, DbTypeExpression convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableTimeSpanCastFunctionExpression As(string alias)
        {
            base.As(alias);
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
