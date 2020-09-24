using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32ExpressionMediator :
        NullableExpressionMediator<int>,
        IEquatable<NullableInt32ExpressionMediator>
    {
        #region constructors
        private NullableInt32ExpressionMediator()
        {
        }

        public NullableInt32ExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableInt32ExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableInt32ExpressionMediator As(string alias)
            => new NullableInt32ExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32ExpressionMediator obj)
            => obj is NullableInt32ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableInt32ExpressionMediator operator +(NullableInt32ExpressionMediator a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32ExpressionMediator a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32ExpressionMediator a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32ExpressionMediator a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32ExpressionMediator a, AliasExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
