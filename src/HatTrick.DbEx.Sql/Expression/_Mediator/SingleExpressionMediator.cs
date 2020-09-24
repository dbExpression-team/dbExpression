using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleExpressionMediator :
        ExpressionMediator<float>,
        IEquatable<SingleExpressionMediator>
    {
        #region constructors
        private SingleExpressionMediator()
        {
        }

        public SingleExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected SingleExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new SingleExpressionMediator As(string alias)
            => new SingleExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(SingleExpressionMediator obj)
            => obj is SingleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
