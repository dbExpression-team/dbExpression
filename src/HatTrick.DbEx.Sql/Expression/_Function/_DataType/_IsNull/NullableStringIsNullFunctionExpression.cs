using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringIsNullFunctionExpression :
        NullableIsNullFunctionExpression<string,string>,
        NullableStringElement,
        AnyStringElement,
        IEquatable<NullableStringIsNullFunctionExpression>
    {
        #region constructors
        public NullableStringIsNullFunctionExpression(AnyStringElement expression, NullableStringElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableStringElement As(string alias)
            => new NullableStringSelectExpression(this).As(alias);
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
