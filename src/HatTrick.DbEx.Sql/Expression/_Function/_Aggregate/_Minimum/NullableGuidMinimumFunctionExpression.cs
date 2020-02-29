using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidMinimumFunctionExpression :
        NullableMinimumFunctionExpression<Guid>,
        IEquatable<NullableGuidMinimumFunctionExpression>
    {
        #region constructors
        public NullableGuidMinimumFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion

        #region as
        public new NullableGuidMinimumFunctionExpression As(string alias)
        {
            base.As(alias);
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
