using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool>(BooleanFieldExpression a) => new SelectExpression<bool>(new ExpressionContainer(a));
        public static implicit operator BooleanExpressionMediator(BooleanFieldExpression a) => new BooleanExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(BooleanFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        #region bool
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, bool b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, bool? b) => new FilterExpression<bool>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool? a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionContainer(new LiteralExpression<bool?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool> operator ==(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanFieldExpression a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(BooleanFieldExpression a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
