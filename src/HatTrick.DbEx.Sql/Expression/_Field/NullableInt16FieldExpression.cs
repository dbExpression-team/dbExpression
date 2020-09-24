using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableInt16FieldExpression : 
        NullableFieldExpression<short>,
        IEquatable<NullableInt16FieldExpression>
    {
        #region constructors
        protected NullableInt16FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(short), entity)
        {

        }

        protected NullableInt16FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(short), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableInt16FieldExpression obj)
            => obj is NullableInt16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableInt16ExpressionMediator operator +(NullableInt16FieldExpression a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16FieldExpression a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16FieldExpression a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16FieldExpression a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16FieldExpression a, AliasExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
