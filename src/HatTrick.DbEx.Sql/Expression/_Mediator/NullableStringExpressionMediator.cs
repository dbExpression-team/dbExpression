using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringExpressionMediator :
        ExpressionMediator<string>,
        NullableStringElement,
        AnyStringElement,
        IEquatable<NullableStringExpressionMediator>
    {
        #region constructors
        private NullableStringExpressionMediator()
        {
        }

        public NullableStringExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected NullableStringExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public NullableStringElement As(string alias)
            => new NullableStringExpressionMediator(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableStringExpressionMediator obj)
            => obj is NullableStringExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableStringExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
