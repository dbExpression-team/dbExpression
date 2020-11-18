using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringIsNullFunctionExpression :
        NullableIsNullFunctionExpression<string,string>,
        NullStringElement,
        AnyStringElement,
        IEquatable<NullableStringIsNullFunctionExpression>
    {
        #region constructors
        public NullableStringIsNullFunctionExpression(AnyStringElement expression, NullStringElement value)
            : base(expression, value)
        {

        }

        protected NullableStringIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullStringElement As(string alias)
            => new NullableStringIsNullFunctionExpression(base.Expression, base.Value, alias);
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
