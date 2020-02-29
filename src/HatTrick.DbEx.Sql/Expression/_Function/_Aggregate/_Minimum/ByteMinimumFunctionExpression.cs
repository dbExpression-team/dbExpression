using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteMinimumFunctionExpression :
        MinimumFunctionExpression<byte>,
        IEquatable<ByteMinimumFunctionExpression>
    {
        #region constructors
        public ByteMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new ByteMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
