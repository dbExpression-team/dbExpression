using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleExpressionMediator :
        NullableExpressionMediator<double>,
        IEquatable<NullableDoubleExpressionMediator>
    {
        #region constructors
        private NullableDoubleExpressionMediator()
        {
        }

        public NullableDoubleExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableDoubleExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableDoubleExpressionMediator As(string alias)
            => new NullableDoubleExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDoubleExpressionMediator obj)
            => obj is NullableDoubleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDoubleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableDoubleExpressionMediator operator +(NullableDoubleExpressionMediator a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableDoubleExpressionMediator a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableDoubleExpressionMediator a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableDoubleExpressionMediator a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableDoubleExpressionMediator a, AliasExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
