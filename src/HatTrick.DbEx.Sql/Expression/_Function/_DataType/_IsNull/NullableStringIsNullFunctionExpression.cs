using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringIsNullFunctionExpression :
        NullableIsNullFunctionExpression<string>,
        IEquatable<NullableStringIsNullFunctionExpression>
    {
        #region constructors
        public NullableStringIsNullFunctionExpression(ExpressionMediator<string> expression, ExpressionMediator<string> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableStringIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableStringIsNullFunctionExpression obj)
            => obj is NullableStringIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
