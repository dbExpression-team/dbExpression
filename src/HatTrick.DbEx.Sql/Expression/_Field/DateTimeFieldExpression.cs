using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DateTimeFieldExpression : 
        FieldExpression<DateTime>,
        IEquatable<DateTimeFieldExpression>
    {
        #region constructors
        protected DateTimeFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(DateTime), entity)
        {

        }

        protected DateTimeFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(DateTime), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(DateTimeFieldExpression obj)
            => obj is DateTimeFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DateTimeFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        #region alias
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, AliasExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, AliasExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion
    }
}
