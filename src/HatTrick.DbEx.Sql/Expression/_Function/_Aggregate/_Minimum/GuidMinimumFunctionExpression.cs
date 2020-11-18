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
        public GuidMinimumFunctionExpression(GuidElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        protected GuidMinimumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidMinimumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
