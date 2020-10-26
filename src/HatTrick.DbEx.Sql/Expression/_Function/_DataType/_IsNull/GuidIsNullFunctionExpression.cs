using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidIsNullFunctionExpression :
        IsNullFunctionExpression<Guid>,
        IEquatable<GuidIsNullFunctionExpression>
    {
        #region constructors
        public GuidIsNullFunctionExpression(ExpressionMediator<Guid> expression, ExpressionMediator<Guid> value) : base(expression, value)
        {
        }
        #endregion

        #region as
        public new GuidIsNullFunctionExpression As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidIsNullFunctionExpression obj)
            => obj is GuidIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
