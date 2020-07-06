using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteIsNullFunctionExpression :
        NullableIsNullFunctionExpression<byte>,
        IEquatable<NullableByteIsNullFunctionExpression>
    {
        #region constructors
        public NullableByteIsNullFunctionExpression(NullableExpressionMediator<byte> expression, ExpressionMediator<byte> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableByteIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
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
