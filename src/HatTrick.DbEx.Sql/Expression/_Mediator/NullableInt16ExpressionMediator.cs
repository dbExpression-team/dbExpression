using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16ExpressionMediator :
        NullableExpressionMediator<short>,
        IEquatable<NullableInt16ExpressionMediator>
    {
        #region constructors
        private NullableInt16ExpressionMediator()
        {
        }

        public NullableInt16ExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt16ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt16ExpressionMediator obj)
            => obj is NullableInt16ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
