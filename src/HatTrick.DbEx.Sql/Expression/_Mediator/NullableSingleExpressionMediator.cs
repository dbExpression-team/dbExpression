using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleExpressionMediator :
        NullableExpressionMediator<float>,
        IEquatable<NullableSingleExpressionMediator>
    {
        #region constructors
        private NullableSingleExpressionMediator()
        {
        }

        public NullableSingleExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableSingleExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableSingleExpressionMediator As(string alias)
            => new NullableSingleExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleExpressionMediator obj)
            => obj is NullableSingleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableSingleExpressionMediator operator +(NullableSingleExpressionMediator a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleExpressionMediator a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleExpressionMediator a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleExpressionMediator a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleExpressionMediator a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
