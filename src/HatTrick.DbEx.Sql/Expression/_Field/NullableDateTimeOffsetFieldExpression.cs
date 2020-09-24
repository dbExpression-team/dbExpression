using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeOffsetFieldExpression : 
        NullableFieldExpression<DateTimeOffset>,
        IEquatable<NullableDateTimeOffsetFieldExpression>
    {
        #region constructors
        protected NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(DateTimeOffset), entity)
        {

        }

        protected NullableDateTimeOffsetFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(DateTimeOffset), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeOffsetFieldExpression obj)
            => obj is NullableDateTimeOffsetFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeOffsetFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetFieldExpression a, AliasExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetFieldExpression a, AliasExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion
    }
}
