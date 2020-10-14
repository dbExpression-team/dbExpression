using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator StringExpressionMediator(StringMinimumFunctionExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringMinimumFunctionExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
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

        #region mediator
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
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<bool> operator ==(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringMinimumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringMinimumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringMinimumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
