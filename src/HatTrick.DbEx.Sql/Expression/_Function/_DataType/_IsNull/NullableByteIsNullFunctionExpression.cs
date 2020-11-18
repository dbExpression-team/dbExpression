using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteIsNullFunctionExpression :
        NullableIsNullFunctionExpression<byte,byte?>,
        NullByteElement,
        AnyByteElement,
        IEquatable<NullableByteIsNullFunctionExpression>
    {
        #region constructors
        public NullableByteIsNullFunctionExpression(AnyByteElement expression, NullByteElement value) 
            : base(expression, value)
        {

        }

        protected NullableByteIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullByteElement As(string alias)
            => new NullableByteIsNullFunctionExpression(base.Expression, base.Value, alias);
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
