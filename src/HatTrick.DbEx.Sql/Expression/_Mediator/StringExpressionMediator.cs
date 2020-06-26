using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringExpressionMediator :
        ExpressionMediator<string>,
        IEquatable<StringExpressionMediator>
    {
        #region constructors
        private StringExpressionMediator()
        {
        }

        public StringExpressionMediator(ExpressionContainer expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new StringExpressionMediator As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression(new ExpressionContainer(this), new ExpressionContainer(new LiteralExpression<string>(phrase)), FilterExpressionOperator.Like);
        #endregion

        #region equals
        public bool Equals(StringExpressionMediator obj)
            => obj is StringExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        public static StringExpressionMediator operator +(StringExpressionMediator a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        #endregion
    }
}
