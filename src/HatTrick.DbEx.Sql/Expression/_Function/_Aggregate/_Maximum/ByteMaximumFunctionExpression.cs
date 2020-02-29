using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMaximumFunctionExpression :
        MaximumFunctionExpression<byte>,
        IEquatable<ByteMaximumFunctionExpression>
    {
        #region constructors
        public ByteMaximumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new ByteMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
