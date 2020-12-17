using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCeilingFunctionExpression :
        NullableCeilFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteCeilingFunctionExpression>
    {
        #region constructors
        public NullableByteCeilingFunctionExpression(NullableByteElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
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
