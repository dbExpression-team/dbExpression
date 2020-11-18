using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringExpressionMediator :
        ExpressionMediator<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringExpressionMediator>
    {
        #region constructors
        private StringExpressionMediator()
        {
        }

        public StringExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected StringExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringExpressionMediator(base.Expression, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression(this, new StringExpressionMediator(new LikeExpression(phrase)), FilterExpressionOperator.None);
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
        #region mediators
        public static StringExpressionMediator operator +(StringExpressionMediator a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion
        #endregion
    }
}
