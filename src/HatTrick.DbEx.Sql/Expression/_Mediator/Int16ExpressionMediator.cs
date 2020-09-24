using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int16ExpressionMediator :
        ExpressionMediator<short>,
        IEquatable<Int16ExpressionMediator>
    {
        #region constructors
        private Int16ExpressionMediator()
        {
        }

        public Int16ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected Int16ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new Int16ExpressionMediator As(string alias)
            => new Int16ExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(Int16ExpressionMediator obj)
            => obj is Int16ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static Int16ExpressionMediator operator +(Int16ExpressionMediator a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(Int16ExpressionMediator a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(Int16ExpressionMediator a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(Int16ExpressionMediator a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(Int16ExpressionMediator a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
