using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMaximumFunctionExpression :
        NullableMaximumFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteMaximumFunctionExpression>
    {
        #region constructors
        public NullableByteMaximumFunctionExpression(NullByteElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableByteMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias)
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
