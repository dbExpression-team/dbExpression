using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator StringExpressionMediator(StringMaximumFunctionExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringMaximumFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte



        #endregion
        
        #region decimal



        #endregion
        
        #region double



        #endregion
        
        #region float



        #endregion
        
        #region short



        #endregion
        
        #region int



        #endregion
        
        #region long



        #endregion
        
        #endregion

        #region fields
        #region byte

        #endregion        
        #region decimal

        #endregion        
        #region double

        #endregion        
        #region float

        #endregion        
        #region short

        #endregion        
        #region int

        #endregion        
        #region long

        #endregion        
        #endregion

        #region mediators
        #region byte

        #endregion        
        #region decimal

        #endregion        
        #region double

        #endregion        
        #region float

        #endregion        
        #region short

        #endregion        
        #region int

        #endregion        
        #region long

        #endregion        
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region string
        public static FilterExpressionSet operator ==(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(StringMaximumFunctionExpression a, string b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(string a, StringMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(StringMaximumFunctionExpression a, StringFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region alias
        public static FilterExpressionSet operator ==(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(StringMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
