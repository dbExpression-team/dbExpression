using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidIsNullFunctionExpression :
        NullableIsNullFunctionExpression<Guid>,
        IEquatable<NullableGuidIsNullFunctionExpression>
    {
        #region constructors
        public NullableGuidIsNullFunctionExpression(ExpressionMediator<Guid> expression, ExpressionMediator<Guid> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new NullableGuidIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableGuidIsNullFunctionExpression obj)
            => obj is NullableGuidIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
