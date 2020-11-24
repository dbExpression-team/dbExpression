using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteIsNullFunctionExpression :
        IsNullFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteIsNullFunctionExpression>
    {
        #region constructors
        public ByteIsNullFunctionExpression(AnyByteElement expression, ByteElement value) : base(expression, value)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteIsNullFunctionExpression obj)
            => obj is ByteIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
