using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnAppender :
        IAssemblyPartAppender<JoinOnExpression>
    {
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators());

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as JoinOnExpression, builder, context);

        public void AppendPart(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.ExpressionOperator == FilterExpressionOperator.In)
            {
                throw new InvalidOperationException("Join on clause does not support in");
            }

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            builder.AppendPart(expression.LeftPart, context);
            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
            builder.AppendPart(expression.RightPart, context);
            context.PopAppendStyles();
        }
    }
}
