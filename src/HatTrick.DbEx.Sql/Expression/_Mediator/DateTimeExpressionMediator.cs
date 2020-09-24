using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeExpressionMediator :
        ExpressionMediator<DateTime>,
        IEquatable<DateTimeExpressionMediator>
    {
        #region constructors
        private DateTimeExpressionMediator()
        {
        }

        public DateTimeExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected DateTimeExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new DateTimeExpressionMediator As(string alias)
            => new DateTimeExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(DateTimeExpressionMediator obj)
            => obj is DateTimeExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, AliasExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, AliasExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion
    }
}
