using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringExpressionMediator :
        ExpressionMediator<string>,
        IEquatable<NullableStringExpressionMediator>
    {
        #region constructors
        private NullableStringExpressionMediator()
        {
        }

        public NullableStringExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableStringExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableStringExpressionMediator As(string alias)
            => new NullableStringExpressionMediator(this.Expression, alias);
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
