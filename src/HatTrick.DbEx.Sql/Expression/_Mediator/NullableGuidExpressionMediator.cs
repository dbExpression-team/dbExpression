using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidExpressionMediator :
        NullableExpressionMediator<Guid,Guid?>,
        NullableGuidElement,
        AnyGuidElement,
        IEquatable<NullableGuidExpressionMediator>
    {
        #region constructors
        private NullableGuidExpressionMediator()
        {
        }

        public NullableGuidExpressionMediator(IExpressionElement expression) : base(expression, typeof(Guid?))
        {
        }

        protected NullableGuidExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(Guid?), alias)
        {
        }
        #endregion

        #region as
        public NullableGuidElement As(string alias)
            => new NullableGuidSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableGuidExpressionMediator obj)
            => obj is NullableGuidExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableGuidExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
