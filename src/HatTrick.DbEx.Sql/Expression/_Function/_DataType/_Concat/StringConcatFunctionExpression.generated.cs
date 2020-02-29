
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringConcatFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringConcatFunctionExpression a) => new SelectExpression<string>(new ExpressionContainer(a));
        public static implicit operator StringExpressionMediator(StringConcatFunctionExpression a) => new StringExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(StringConcatFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringConcatFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region string
        public static StringExpressionMediator operator +(StringConcatFunctionExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));

        public static StringExpressionMediator operator +(string a, StringConcatFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));


        #endregion

        #endregion

        #region mediator
        #region string
        public static StringExpressionMediator operator +(StringConcatFunctionExpression a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<string> operator ==(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringConcatFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(string a, StringConcatFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region mediator
        public static FilterExpression<string> operator ==(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringConcatFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
