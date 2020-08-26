using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool>(BooleanExpressionMediator a) => new SelectExpression<bool>(a);
        public static implicit operator OrderByExpression(BooleanExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        public static FilterExpression<bool> operator ==(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanExpressionMediator a, bool b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanExpressionMediator a, bool? b) => new FilterExpression<bool>(a, new BooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool? a, BooleanExpressionMediator b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
