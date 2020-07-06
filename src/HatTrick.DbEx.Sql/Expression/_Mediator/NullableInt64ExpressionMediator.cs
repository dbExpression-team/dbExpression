using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64ExpressionMediator :
        NullableExpressionMediator<long>,
        IEquatable<NullableInt64ExpressionMediator>
    {
        #region constructors
        private NullableInt64ExpressionMediator()
        {
        }

        public NullableInt64ExpressionMediator(IDbExpression expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new NullableInt64ExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableInt64ExpressionMediator obj)
            => obj is NullableInt64ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
