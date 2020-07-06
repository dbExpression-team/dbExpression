using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMaximumFunctionExpression :
        NullableMaximumFunctionExpression<byte>,
        IEquatable<NullableByteMaximumFunctionExpression>
    {
        #region constructors
        public NullableByteMaximumFunctionExpression(NullableExpressionMediator<byte> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableByteMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteMaximumFunctionExpression obj)
            => obj is NullableByteMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
