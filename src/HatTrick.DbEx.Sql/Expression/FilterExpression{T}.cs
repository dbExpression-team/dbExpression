using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression<T> : FilterExpression
    {
        public FilterExpression(ExpressionContainer leftArg, ExpressionContainer rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }
    }
}
