using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDecimalFieldExpression : 
        NullableFieldExpression<decimal>,
        IEquatable<NullableDecimalFieldExpression>
    {
        #region constructors
        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(decimal), entity)
        {

        }

        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(decimal), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression obj)
            => obj is NullableDecimalFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static NullableDecimalExpressionMediator operator +(NullableDecimalFieldExpression a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableDecimalFieldExpression a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableDecimalFieldExpression a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableDecimalFieldExpression a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableDecimalFieldExpression a, AliasExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
