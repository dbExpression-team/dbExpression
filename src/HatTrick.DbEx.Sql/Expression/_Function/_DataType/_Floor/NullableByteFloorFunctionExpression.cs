using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFloorFunctionExpression :
        NullableFloorFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteFloorFunctionExpression>
    {
        #region constructors
        public NullableByteFloorFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
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
