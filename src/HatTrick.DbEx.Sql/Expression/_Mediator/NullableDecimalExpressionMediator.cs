using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDecimalExpressionMediator :
        NullableExpressionMediator<decimal>,
        IEquatable<NullableDecimalExpressionMediator>
    {
        #region constructors
        private NullableDecimalExpressionMediator()
        {
        }

        public NullableDecimalExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableDecimalExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableDecimalExpressionMediator As(string alias)
            => new NullableDecimalExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalExpressionMediator obj)
            => obj is NullableDecimalExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableDecimalExpressionMediator operator +(NullableDecimalExpressionMediator a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalExpressionMediator a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalExpressionMediator a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalExpressionMediator a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalExpressionMediator a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
