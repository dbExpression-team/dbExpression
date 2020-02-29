using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64IsNullFunctionExpression :
        NullableIsNullFunctionExpression<long>,
        IEquatable<NullableInt64IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt64IsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableInt64IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64IsNullFunctionExpression obj)
            => obj is NullableInt64IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
