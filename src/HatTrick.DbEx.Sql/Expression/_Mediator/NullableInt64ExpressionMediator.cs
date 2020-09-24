using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64ExpressionMediator :
        NullableExpressionMediator<long>,
        IEquatable<NullableInt64ExpressionMediator>
    {
        #region constructors
        private NullableInt64ExpressionMediator()
        {
        }

        public NullableInt64ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableInt64ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableInt64ExpressionMediator As(string alias)
            => new NullableInt64ExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt64ExpressionMediator obj)
            => obj is NullableInt64ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
