using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMaximumFunctionExpression :
        NullableMaximumFunctionExpression<Guid>,
        IEquatable<NullableGuidMaximumFunctionExpression>
    {
        #region constructors
        public NullableGuidMaximumFunctionExpression(NullableExpressionMediator<Guid> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableGuidMaximumFunctionExpression As(string alias)
        {
            base.As(alias);
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
