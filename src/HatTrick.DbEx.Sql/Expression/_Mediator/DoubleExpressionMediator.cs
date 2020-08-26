using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleExpressionMediator :
        ExpressionMediator<double>,
        IEquatable<DoubleExpressionMediator>
    {
        #region constructors
        private DoubleExpressionMediator()
        {
        }

        public DoubleExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected DoubleExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new DoubleExpressionMediator As(string alias)
            => new DoubleExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(DoubleExpressionMediator obj)
            => obj is DoubleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
