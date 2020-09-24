using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class ByteFieldExpression : 
        FieldExpression<byte>,
        IEquatable<ByteFieldExpression>
    {
        #region constructors
        protected ByteFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(string), entity)
        {

        }

        protected ByteFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(string), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(ByteFieldExpression obj)
            => obj is ByteFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static ByteExpressionMediator operator +(ByteFieldExpression a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(ByteFieldExpression a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(ByteFieldExpression a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(ByteFieldExpression a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(ByteFieldExpression a, AliasExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
