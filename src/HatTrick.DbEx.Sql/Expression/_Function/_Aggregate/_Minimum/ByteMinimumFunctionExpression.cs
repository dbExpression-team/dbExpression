using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMinimumFunctionExpression :
        MinimumFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteMinimumFunctionExpression>
    {
        #region constructors
        public ByteMinimumFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected ByteMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(ByteMinimumFunctionExpression obj)
            => obj is ByteMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
