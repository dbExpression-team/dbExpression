using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidExpressionMediator :
        ExpressionMediator<Guid>,
        IEquatable<GuidExpressionMediator>
    {
        #region constructors
        private GuidExpressionMediator()
        {
        }

        public GuidExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new GuidExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(GuidExpressionMediator obj)
            => obj is GuidExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is GuidExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
