using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteMinimumFunctionExpression :
        NullableMinimumFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteMinimumFunctionExpression>
    {
        #region constructors
        public NullableByteMinimumFunctionExpression(NullByteElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableByteMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
