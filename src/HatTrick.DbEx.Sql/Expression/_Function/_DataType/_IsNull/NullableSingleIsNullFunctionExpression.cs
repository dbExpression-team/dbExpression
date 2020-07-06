using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleIsNullFunctionExpression :
        NullableIsNullFunctionExpression<float>,
        IEquatable<NullableSingleIsNullFunctionExpression>
    {
        #region constructors
        public NullableSingleIsNullFunctionExpression(NullableExpressionMediator<float> expression, ExpressionMediator<float> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableSingleIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleIsNullFunctionExpression obj)
            => obj is NullableSingleIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
