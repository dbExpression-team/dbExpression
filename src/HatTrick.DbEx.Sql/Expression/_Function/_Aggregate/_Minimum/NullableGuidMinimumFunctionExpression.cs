using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMinimumFunctionExpression :
        NullableMinimumFunctionExpression<Guid,Guid?>,
        NullGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidMinimumFunctionExpression>
    {
        #region constructors
        public NullableGuidMinimumFunctionExpression(NullGuidElement expression, bool isDistinct) 
            : base(expression, isDistinct)
        {

        }

        protected NullableGuidMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) 
            : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public NullGuidElement As(string alias)
            => new NullableGuidMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidMinimumFunctionExpression obj)
            => obj is NullableGuidMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
