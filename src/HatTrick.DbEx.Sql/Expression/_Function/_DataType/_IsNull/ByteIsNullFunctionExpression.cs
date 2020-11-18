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

        protected ByteIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteIsNullFunctionExpression(base.Expression, base.Value, alias);
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
