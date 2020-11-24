using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMinimumFunctionExpression :
        NullableMinimumFunctionExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidMinimumFunctionExpression>
    {
        #region constructors
        public NullableGuidMinimumFunctionExpression(NullableGuidElement expression) 
            : base(expression)
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

        #region distinct
        public NullableGuidMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
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
