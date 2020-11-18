using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidIsNullFunctionExpression :
        IsNullFunctionExpression<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidIsNullFunctionExpression>
    {
        #region constructors
        public GuidIsNullFunctionExpression(AnyGuidElement expression, GuidElement value) : base(expression, value)
        {

        }

        protected GuidIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value, string alias) : base(expression, value, alias)
        {

        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidIsNullFunctionExpression(base.Expression, base.Value, alias);
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
