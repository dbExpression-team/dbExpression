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

        public NullableInt64ExpressionMediator(IExpression expression) : base(expression, typeof(long?))
        {
        }

        protected NullableInt64ExpressionMediator(IExpression expression, string alias) : base(expression, typeof(long?), alias)
        {
        }
        #endregion

        #region as
        public new NullableInt64ExpressionMediator As(string alias)
            => new NullableInt64ExpressionMediator(this.Expression, alias);
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
