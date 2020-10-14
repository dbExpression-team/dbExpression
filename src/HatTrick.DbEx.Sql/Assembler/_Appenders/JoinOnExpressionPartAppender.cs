using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionPartAppender : PartAppender<JoinOnExpression>
    {
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => $" {x} "));

        public override void AppendPart(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            try
            {
                builder.AppendPart(expression.LeftArg, context);
                builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
                builder.AppendPart(expression.RightArg, context);
            }
            finally
            {
                context.PopAppendStyles();
            }
        }
    }
}
