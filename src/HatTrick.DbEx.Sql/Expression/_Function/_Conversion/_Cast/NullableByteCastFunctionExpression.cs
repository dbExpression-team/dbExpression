using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCastFunctionExpression :
        NullableCastFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteCastFunctionExpression>
    {
        #region constructors
        public NullableByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
        {
            Alias = alias;
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
