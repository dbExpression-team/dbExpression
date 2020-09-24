using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int32FieldExpression : 
        FieldExpression<int>,
        IEquatable<Int32FieldExpression>
    {
        #region constructors
        protected Int32FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(int), entity)
        {

        }

        protected Int32FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(int), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int32FieldExpression obj)
            => obj is Int32FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int32FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static Int32ExpressionMediator operator +(Int32FieldExpression a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FieldExpression a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FieldExpression a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FieldExpression a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FieldExpression a, AliasExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

    }
}
