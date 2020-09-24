using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DoubleFieldExpression : 
        FieldExpression<double>,
        IEquatable<DoubleFieldExpression>
    {
        #region constructors
        protected DoubleFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(double), entity)
        {

        }

        protected DoubleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(double), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression obj)
            => obj is DoubleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static DoubleExpressionMediator operator +(DoubleFieldExpression a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleFieldExpression a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleFieldExpression a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleFieldExpression a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleFieldExpression a, AliasExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
