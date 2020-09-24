using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class Int16FieldExpression : 
        FieldExpression<short>,
        IEquatable<Int16FieldExpression>
    {
        #region constructors
        protected Int16FieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(short), entity)
        {

        }

        protected Int16FieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(short), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression obj)
            => obj is Int16FieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static Int16ExpressionMediator operator +(Int16FieldExpression a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(Int16FieldExpression a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(Int16FieldExpression a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(Int16FieldExpression a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(Int16FieldExpression a, AliasExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion
    }
}
