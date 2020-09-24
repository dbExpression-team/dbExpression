using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class StringFieldExpression : 
        FieldExpression<string>,
        IEquatable<StringFieldExpression>
    {
        #region constructors
        protected StringFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(string), entity)
        {

        }

        protected StringFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(string), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(StringFieldExpression obj)
            => obj is StringFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static StringExpressionMediator operator +(StringFieldExpression a, AliasExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion
    }
}
