using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidExpressionMediator :
        NullableExpressionMediator<Guid>,
        IEquatable<NullableGuidExpressionMediator>
    {
        #region constructors
        private NullableGuidExpressionMediator()
        {
        }

        public NullableGuidExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableGuidExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
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
