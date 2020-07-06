using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalCastFunctionExpression :
        NullableCastFunctionExpression<decimal>,
        IEquatable<NullableDecimalCastFunctionExpression>
    {
        #region constructors
        public NullableDecimalCastFunctionExpression(ExpressionMediator expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableDecimalCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalCastFunctionExpression obj)
            => obj is NullableDecimalCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
