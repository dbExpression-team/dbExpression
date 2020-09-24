using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetExpressionMediator :
        NullableExpressionMediator<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetExpressionMediator>
    {
        #region constructors
        private NullableDateTimeOffsetExpressionMediator()
        {
        }

        public NullableDateTimeOffsetExpressionMediator(IExpression expression) : base(expression)
        {
        }

        protected NullableDateTimeOffsetExpressionMediator(IExpression expression, string alias) : base(expression, alias)
        {
        }
        #endregion

        #region as
        public new NullableDateTimeOffsetExpressionMediator As(string alias)
            => new NullableDateTimeOffsetExpressionMediator(this.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetExpressionMediator obj)
            => obj is NullableDateTimeOffsetExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, AliasExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, AliasExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion
    }
}
