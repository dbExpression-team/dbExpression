using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpression<T> : FilterExpression
    {
        public FilterExpression(IDbExpression leftArg, IDbExpression rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(object leftArg, IDbExpression rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(IDbExpression leftArg, DBNull rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(DBNull leftArg, IDbExpression rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression((Type,object) leftArg, IDbExpression rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }

        public FilterExpression(IDbExpression leftArg, (Type, object) rightArg, FilterExpressionOperator expressionOperator)
            : base(leftArg, rightArg, expressionOperator)
        {
        }
    }
}
