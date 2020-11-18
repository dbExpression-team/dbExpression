using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteCastFunctionExpression :
        CastFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteCastFunctionExpression>
    {
        #region constructors
        public ByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(byte))
        {

        }

        protected ByteCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias)
            : base(expression, convertToDbType, typeof(byte), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(ByteCastFunctionExpression obj)
            => obj is ByteCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
