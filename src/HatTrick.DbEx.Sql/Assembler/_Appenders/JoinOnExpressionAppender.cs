using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionAppender : ExpressionElementAppender<JoinOnExpression>
    {
        #region internals
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));
        #endregion

        #region methods
        public override void AppendElement(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            try
            {
                if (expression.Negate)
                {
                    builder.Appender.Write("NOT (");
                }
                builder.AppendElement(expression.LeftArg, context);

                builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
                context.PushField(expression.LeftArg.AsFieldExpression());
                try
                {
                    builder.AppendElement(expression.RightArg, context);
                }
                finally
                {
                    context.PopField();
                }

                if (expression.Negate)
                {
                    builder.Appender.Write(')');
                }
            }
            finally
            {
                context.PopAppendStyles();
            }
        }
        #endregion
    }
}
