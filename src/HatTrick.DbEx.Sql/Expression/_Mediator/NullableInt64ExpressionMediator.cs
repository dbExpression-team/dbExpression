using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64ExpressionMediator :
        NullableExpressionMediator<long,long?>,
        NullableInt64Element,
        AnyInt64Element,
        IEquatable<NullableInt64ExpressionMediator>
    {
        #region constructors
        private NullableInt64ExpressionMediator()
        {
        }

        public NullableInt64ExpressionMediator(IExpressionElement expression) : base(expression, typeof(long?))
        {
        }

        protected NullableInt64ExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(long?), alias)
        {
        }
        #endregion

        #region as
        public NullableInt64Element As(string alias)
            => new NullableInt64SelectExpression(this).As(alias);
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
