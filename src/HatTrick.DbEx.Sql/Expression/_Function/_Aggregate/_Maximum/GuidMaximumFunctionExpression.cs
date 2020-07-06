using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidMaximumFunctionExpression :
        MaximumFunctionExpression<Guid>,
        IEquatable<GuidMaximumFunctionExpression>
    {
        #region constructors
        public GuidMaximumFunctionExpression(ExpressionMediator<Guid> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new GuidMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
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
