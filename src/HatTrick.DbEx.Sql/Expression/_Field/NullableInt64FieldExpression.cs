using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt64FieldExpression : 
        NullableFieldExpression<long>,
        IEquatable<NullableInt64FieldExpression>
    {
        #region constructors
        protected NullableInt64FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(long?), entity)
        {

        }

        protected NullableInt64FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(long?), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt64FieldExpression obj)
            => obj is NullableInt64FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt64FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableInt64ExpressionMediator operator +(NullableInt64FieldExpression a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64FieldExpression a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64FieldExpression a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64FieldExpression a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64FieldExpression a, AliasExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
