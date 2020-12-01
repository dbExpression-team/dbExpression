using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableStringExpressionMediator(NullableStringIsNullFunctionExpression a) => new NullableStringExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableStringIsNullFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableStringIsNullFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
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
        public static NullableStringExpressionMediator operator +(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new NullableStringExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

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

        #region alias
        public static ObjectExpressionMediator operator +(NullableStringIsNullFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region string
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(string a, NullableStringIsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringIsNullFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
