using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMaximumFunctionExpression :
        MaximumFunctionExpression<byte>,
        ByteElement,
        AnyByteElement,
        IEquatable<ByteMaximumFunctionExpression>
    {
        #region constructors
        public ByteMaximumFunctionExpression(ByteElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected ByteMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public ByteElement As(string alias)
            => new ByteMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(ByteMaximumFunctionExpression obj)
            => obj is ByteMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
