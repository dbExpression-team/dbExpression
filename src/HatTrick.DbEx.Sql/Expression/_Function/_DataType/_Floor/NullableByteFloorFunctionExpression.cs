using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFloorFunctionExpression :
        NullableFloorFunctionExpression<byte>,
        IEquatable<NullableByteFloorFunctionExpression>
    {
        #region constructors
        public NullableByteFloorFunctionExpression(NullableExpressionMediator<byte> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableByteFloorFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteFloorFunctionExpression obj)
            => obj is NullableByteFloorFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteFloorFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
