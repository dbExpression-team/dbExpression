using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator StringExpressionMediator(StringCastFunctionExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringCastFunctionExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringCastFunctionExpression a) => new GroupByExpression(new StringExpressionMediator(a));
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
        public static StringExpressionMediator operator +(StringCastFunctionExpression a, string b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, StringCastFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));


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
        
        #region string
        public static StringExpressionMediator operator +(StringCastFunctionExpression a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpressionSet operator ==(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(StringCastFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(string a, StringCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(StringCastFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion
    }
}
