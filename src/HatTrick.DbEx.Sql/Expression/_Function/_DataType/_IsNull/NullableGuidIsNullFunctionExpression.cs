using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidIsNullFunctionExpression :
        NullableIsNullFunctionExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidIsNullFunctionExpression>
    {
        #region constructors
        public NullableGuidIsNullFunctionExpression(AnyGuidElement expression, NullableGuidElement value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableGuidElement As(string alias)
        {
            Alias = alias;
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
