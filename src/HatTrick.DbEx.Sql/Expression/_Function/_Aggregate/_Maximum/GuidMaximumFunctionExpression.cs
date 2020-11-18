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
        public GuidMaximumFunctionExpression(GuidElement expression, bool isDistinct) : base(expression, isDistinct)
        {

        }

        public GuidMaximumFunctionExpression(IExpressionElement expression, bool isDistinct, string alias) : base(expression, isDistinct, alias)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidMaximumFunctionExpression(base.Expression, base.IsDistinct, alias);
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
