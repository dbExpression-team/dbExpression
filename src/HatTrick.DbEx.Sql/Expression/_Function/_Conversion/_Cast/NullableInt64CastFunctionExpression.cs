using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64CastFunctionExpression :
        NullableCastFunctionExpression<long>,
        IEquatable<NullableInt64CastFunctionExpression>
    {
        #region constructors
        public NullableInt64CastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableInt64CastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64CastFunctionExpression obj)
            => obj is NullableInt64CastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64CastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
