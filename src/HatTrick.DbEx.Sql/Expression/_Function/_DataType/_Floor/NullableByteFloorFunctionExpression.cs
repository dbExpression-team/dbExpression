using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFloorFunctionExpression :
        NullableFloorFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteFloorFunctionExpression>
    {
        #region constructors
        public NullableByteFloorFunctionExpression(NullByteElement expression) : base(expression)
        {

        }

        public NullableByteFloorFunctionExpression(IExpressionElement expression, string alias) : base(expression, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteFloorFunctionExpression(base.Expression, alias);
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
