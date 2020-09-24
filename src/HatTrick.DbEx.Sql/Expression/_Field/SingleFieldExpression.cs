using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class SingleFieldExpression : 
        FieldExpression<float>,
        IEquatable<SingleFieldExpression>
    {
        #region constructors
        protected SingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(float), entity)
        {

        }

        protected SingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(float), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(SingleFieldExpression obj)
            => obj is SingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static SingleExpressionMediator operator +(SingleFieldExpression a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleFieldExpression a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleFieldExpression a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleFieldExpression a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleFieldExpression a, AliasExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
