using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ByteIsNullFunctionExpression :
        IsNullFunctionExpression<byte>,
        IEquatable<ByteIsNullFunctionExpression>
    {
        #region constructors
        public ByteIsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new ByteIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ByteIsNullFunctionExpression obj)
            => obj is ByteIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
