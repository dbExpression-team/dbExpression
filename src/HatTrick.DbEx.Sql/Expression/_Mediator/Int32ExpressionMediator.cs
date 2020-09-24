using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32ExpressionMediator :
        ExpressionMediator<int>,
        IEquatable<Int32ExpressionMediator>
    {
        #region constructors
        private Int32ExpressionMediator()
        {
        }

        public Int32ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected Int32ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new Int32ExpressionMediator As(string alias)
            => new Int32ExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(Int32ExpressionMediator obj)
            => obj is Int32ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static Int32ExpressionMediator operator +(Int32ExpressionMediator a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32ExpressionMediator a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32ExpressionMediator a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32ExpressionMediator a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32ExpressionMediator a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
