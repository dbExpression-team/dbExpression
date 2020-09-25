using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDateTimeFieldExpression : 
        NullableFieldExpression<DateTime>,
        IEquatable<NullableDateTimeFieldExpression>
    {
        #region constructors
        protected NullableDateTimeFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(DateTime?), entity)
        {

        }

        protected NullableDateTimeFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(DateTime?), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDateTimeFieldExpression obj)
            => obj is NullableDateTimeFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDateTimeFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region artithmetic operations
        #region alias
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, AliasExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, AliasExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion
    }
}
