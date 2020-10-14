using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringConcatFunctionExpression
    {
        #region implicit operators
        public static implicit operator StringExpressionMediator(StringConcatFunctionExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringConcatFunctionExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringConcatFunctionExpression a) => new GroupByExpression(new StringExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region string
        public static StringExpressionMediator operator +(StringConcatFunctionExpression a, string b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, StringConcatFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));


        #endregion
        
        #endregion

        #region mediator
        #region string
        public static StringExpressionMediator operator +(StringConcatFunctionExpression a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<bool> operator ==(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringConcatFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringConcatFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
