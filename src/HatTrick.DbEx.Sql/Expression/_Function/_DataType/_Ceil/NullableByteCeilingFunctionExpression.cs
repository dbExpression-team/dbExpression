using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCeilingFunctionExpression :
        NullableCeilFunctionExpression<byte>,
        IEquatable<NullableByteCeilingFunctionExpression>
    {
        #region constructors
        public NullableByteCeilingFunctionExpression(NullableExpressionMediator<byte> expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableByteCeilingFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteCeilingFunctionExpression obj)
            => obj is NullableByteCeilingFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteCeilingFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
