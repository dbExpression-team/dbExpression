using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DecimalExpressionMediator :
        ExpressionMediator<decimal>,
        DecimalElement,
        AnyDecimalElement,
        IEquatable<DecimalExpressionMediator>
    {
        #region constructors
        private DecimalExpressionMediator()
        {
        }

        public DecimalExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected DecimalExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public DecimalElement As(string alias)
            => new DecimalExpressionMediator(base.Expression, alias);
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
