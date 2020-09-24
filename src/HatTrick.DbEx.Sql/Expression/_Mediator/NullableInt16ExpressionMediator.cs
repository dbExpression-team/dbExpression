using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16ExpressionMediator :
        NullableExpressionMediator<short>,
        IEquatable<NullableInt16ExpressionMediator>
    {
        #region constructors
        private NullableInt16ExpressionMediator()
        {
        }

        public NullableInt16ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableInt16ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableInt16ExpressionMediator As(string alias)
            => new NullableInt16ExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt16ExpressionMediator obj)
            => obj is NullableInt16ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
