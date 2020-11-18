using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCastFunctionExpression :
        NullableCastFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteCastFunctionExpression>
    {
        #region constructors
        public NullableByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType)
        {

        }

        protected NullableByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
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
