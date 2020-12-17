using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteIsNullFunctionExpression :
        NullableIsNullFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteIsNullFunctionExpression>
    {
        #region constructors
        public NullableByteIsNullFunctionExpression(AnyByteElement expression, NullableByteElement value) 
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableByteIsNullFunctionExpression obj)
            => obj is NullableByteIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
