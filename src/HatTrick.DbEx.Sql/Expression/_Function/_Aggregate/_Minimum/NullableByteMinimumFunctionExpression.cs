using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMinimumFunctionExpression :
        NullableMinimumFunctionExpression<byte>,
        IEquatable<NullableByteMinimumFunctionExpression>
    {
        #region constructors
        public NullableByteMinimumFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableByteMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteMinimumFunctionExpression obj)
            => obj is NullableByteMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
