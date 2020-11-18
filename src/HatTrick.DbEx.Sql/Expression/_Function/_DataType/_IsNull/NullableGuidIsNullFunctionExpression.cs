using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidIsNullFunctionExpression :
        NullableIsNullFunctionExpression<Guid,Guid?>,
        NullGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidIsNullFunctionExpression>
    {
        #region constructors
        public NullableGuidIsNullFunctionExpression(AnyGuidElement expression, NullGuidElement value)
            : base(expression, value)
        {

        }

        protected NullableGuidIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias)
            : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public NullGuidElement As(string alias)
            => new NullableGuidIsNullFunctionExpression(base.Expression, base.Value, alias);
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
