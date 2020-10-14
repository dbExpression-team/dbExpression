using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringExpressionMediator a) => new SelectExpression<string>(a);
        public static implicit operator OrderByExpression(StringExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data type
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
        public static StringExpressionMediator operator +(StringExpressionMediator a, string b) => new StringExpressionMediator(new ArithmeticExpression(a, new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #endregion

        #region fields
        #endregion

        #region mediators
        #endregion
        #endregion

        #region filter operators
        #region string
        public static FilterExpression<bool> operator ==(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool>(a, new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
