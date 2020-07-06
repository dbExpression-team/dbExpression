using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionPartAppender : PartAppender<JoinOnExpression>
    {
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators());

        public override void AppendPart(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.ExpressionOperator == FilterExpressionOperator.In)
            {
                throw new InvalidOperationException("Join on clause does not support in");
            }

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            builder.AppendPart(expression.LeftArg, context);
            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
            builder.AppendPart(expression.RightArg, context);
            context.PopAppendStyles();
        }
    }
}
