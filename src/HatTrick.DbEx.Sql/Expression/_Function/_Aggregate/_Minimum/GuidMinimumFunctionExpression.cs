using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidMinimumFunctionExpression :
        MinimumFunctionExpression<Guid>,
        IEquatable<GuidMinimumFunctionExpression>
    {
        #region constructors
        public GuidMinimumFunctionExpression(ExpressionMediator<Guid> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new GuidMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
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
