using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCastFunctionExpression :
        NullableCastFunctionExpression<byte>,
        IEquatable<NullableByteCastFunctionExpression>
    {
        #region constructors
        public NullableByteCastFunctionExpression(ExpressionContainer expression, ExpressionContainer convertToDbType) : base(expression, convertToDbType)
        {
        }
        #endregion

        #region as
        public new NullableByteCastFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteCastFunctionExpression obj)
            => obj is NullableByteCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
