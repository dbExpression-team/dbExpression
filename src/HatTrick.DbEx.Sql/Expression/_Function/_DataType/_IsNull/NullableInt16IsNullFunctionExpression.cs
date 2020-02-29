using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16IsNullFunctionExpression :
        NullableIsNullFunctionExpression<short>,
        IEquatable<NullableInt16IsNullFunctionExpression>
    {
        #region constructors
        public NullableInt16IsNullFunctionExpression(ExpressionContainer expression, ExpressionContainer value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableInt16IsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16IsNullFunctionExpression obj)
            => obj is NullableInt16IsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16IsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
