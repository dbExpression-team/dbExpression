using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanExpressionMediator :
        ExpressionMediator<bool>,
        IEquatable<BooleanExpressionMediator>
    {
        #region constructors
        private BooleanExpressionMediator()
        {
        }

        public BooleanExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected BooleanExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new BooleanExpressionMediator As(string alias)
            => new BooleanExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(BooleanExpressionMediator obj)
            => obj is BooleanExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is BooleanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
