using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalExpressionMediator :
        ExpressionMediator<decimal>,
        IEquatable<DecimalExpressionMediator>
    {
        #region constructors
        private DecimalExpressionMediator()
        {
        }

        public DecimalExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected DecimalExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new DecimalExpressionMediator As(string alias)
            => new DecimalExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(DecimalExpressionMediator obj)
            => obj is DecimalExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
