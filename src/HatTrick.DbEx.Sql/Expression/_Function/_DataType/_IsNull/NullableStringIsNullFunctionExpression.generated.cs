using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableStringExpressionMediator(NullableStringIsNullFunctionExpression a) => new NullableStringExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableStringIsNullFunctionExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableStringIsNullFunctionExpression a) => new GroupByExpression(new StringExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
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
        
        #endregion
        
        #region TimeSpan



        
        #endregion
        
        #endregion

        #region mediator
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
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableStringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new StringExpressionMediator(new LiteralExpression<string>(a)), new NullableStringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion
    }
}
