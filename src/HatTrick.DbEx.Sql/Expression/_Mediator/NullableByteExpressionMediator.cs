using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteExpressionMediator :
        NullableExpressionMediator<byte>,
        IEquatable<NullableByteExpressionMediator>
    {
        #region constructors
        private NullableByteExpressionMediator()
        {
        }

        public NullableByteExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableByteExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableByteExpressionMediator As(string alias)
            => new NullableByteExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableByteExpressionMediator obj)
            => obj is NullableByteExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableByteExpressionMediator operator +(NullableByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteExpressionMediator a, AliasExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
