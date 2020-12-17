using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidMaximumFunctionExpression :
        MaximumFunctionExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidMaximumFunctionExpression>
    {
        #region constructors
        public GuidMaximumFunctionExpression(GuidElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public GuidMaximumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidMaximumFunctionExpression obj)
            => obj is GuidMaximumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidMaximumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
