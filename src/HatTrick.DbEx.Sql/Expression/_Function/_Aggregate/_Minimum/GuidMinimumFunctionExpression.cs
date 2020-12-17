using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidMinimumFunctionExpression :
        MinimumFunctionExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidMinimumFunctionExpression>
    {
        #region constructors
        public GuidMinimumFunctionExpression(GuidElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public GuidMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidMinimumFunctionExpression obj)
            => obj is GuidMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
