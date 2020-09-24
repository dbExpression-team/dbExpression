using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableSingleFieldExpression : 
        NullableFieldExpression<float>,
        IEquatable<NullableSingleFieldExpression>
    {
        #region constructors
        protected NullableSingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(float), entity)
        {

        }

        protected NullableSingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(float), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression obj)
            => obj is NullableSingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, AliasExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
