using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidExpressionMediator :
        ExpressionMediator<Guid>,
        GuidElement,
        AnyGuidElement,
        IEquatable<GuidExpressionMediator>
    {
        #region constructors
        private GuidExpressionMediator()
        {
        }

        public GuidExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected GuidExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public GuidElement As(string alias)
            => new GuidExpressionMediator(base.Expression, alias);
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
