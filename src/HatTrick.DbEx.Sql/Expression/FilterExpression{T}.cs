using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression<T> : FilterExpression
    {
        public FilterExpression(ExpressionMediator leftArg, ExpressionMediator rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(ExpressionMediator leftArg, NullableExpressionMediator<T> rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(NullableExpressionMediator<T> leftArg, ExpressionMediator rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(NullableExpressionMediator<T> leftArg, NullableExpressionMediator<T> rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }
    }
}
