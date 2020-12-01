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
        #region data type
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region bool
        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, bool b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(BooleanExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(BooleanExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
