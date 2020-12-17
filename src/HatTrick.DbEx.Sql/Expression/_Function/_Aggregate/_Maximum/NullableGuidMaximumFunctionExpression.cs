using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMaximumFunctionExpression :
        NullableMaximumFunctionExpression<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidMaximumFunctionExpression>
    {
        #region constructors
        public NullableGuidMaximumFunctionExpression(NullableGuidElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableGuidElement As(string alias)
            => new NullableGuidSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableGuidMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableGuidMaximumFunctionExpression obj)
            => obj is NullableGuidMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
