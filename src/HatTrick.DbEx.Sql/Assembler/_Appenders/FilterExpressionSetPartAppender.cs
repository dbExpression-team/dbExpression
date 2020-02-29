using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionSetPartAppender : PartAppender<FilterExpressionSet>
    {
        #region internals
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators());
        #endregion

        #region methods
        public override void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is FilterExpressionSet set)
            {
                if (set.Expression == null)
                    return;

                if (set.IsSingleFilter && set.SingleFilter.Object is FilterExpression singleFilter)
                {
                    builder.AppendPart(singleFilter, context);
                }
                else
                {
                    AppendPart(set, builder, context);
                }
            }
            else
            {
                builder.AppendPart(expression as FilterExpression, context);
            }
        }

        public override void AppendPart(FilterExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression == null || expression.Expression == null)
                return;

            builder.Appender.Write("(");
            if (expression.Negate)
            {
                builder.Appender.Write("NOT (");
            }
            if (expression.Expression.LeftPart != null)
            {
                builder.AppendPart(expression.Expression.LeftPart, context);
            }
            if (expression.Expression.RightPart != null)
            {
                builder.Appender.Write(ConditionalOperatorMap[expression.ConditionalOperator]);
                builder.AppendPart(expression.Expression.RightPart, context);
            }
            if (expression.Negate)
            {
                builder.Appender.Write(")");
            }
            builder.Appender.Write(")");
        }      
        #endregion
    }
}
