using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(NullableStringExpressionMediator a) => new SelectExpression<string>(a);
        public static implicit operator OrderByExpression(NullableStringExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableStringExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region data type 













        #endregion

        #region fields
        #region bool

        #endregion

        #region byte

        #endregion

        #region decimal

        #endregion

        #region DateTime

        #endregion

        #region DateTimeOffset

        #endregion

        #region double

        #endregion

        #region float

        #endregion

        #region Guid

        #endregion

        #region short

        #endregion

        #region int

        #endregion

        #region long

        #endregion

        #region string
        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, StringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));

        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, NullableStringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, new NullableStringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediators













        #endregion
        #endregion

        #region filter operators
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region fields
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, new NullableStringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
