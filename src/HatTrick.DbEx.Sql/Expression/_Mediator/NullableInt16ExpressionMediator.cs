using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16ExpressionMediator :
        NullableExpressionMediator<short,short?>,
        NullInt16Element,
        AnyInt16Element,
        IEquatable<NullableInt16ExpressionMediator>
    {
        #region constructors
        private NullableInt16ExpressionMediator()
        {
        }

        public NullableInt16ExpressionMediator(IExpressionElement expression) : base(expression, typeof(short?))
        {
        }

        protected NullableInt16ExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(short?), alias)
        {
        }
        #endregion

        #region as
        public NullInt16Element As(string alias)
            => new NullableInt16ExpressionMediator(base.Expression, alias);
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
