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

        #region arithmetic operators
        #region alias
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
