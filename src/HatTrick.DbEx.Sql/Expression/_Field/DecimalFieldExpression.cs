using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DecimalFieldExpression : 
        FieldExpression<decimal>,
        IEquatable<DecimalFieldExpression>
    {
        #region constructors
        protected DecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(decimal), entity)
        {

        }

        protected DecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(decimal), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DecimalFieldExpression obj)
            => obj is DecimalFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DecimalFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static DecimalExpressionMediator operator +(DecimalFieldExpression a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DecimalFieldExpression a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DecimalFieldExpression a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DecimalFieldExpression a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DecimalFieldExpression a, AliasExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
