using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionSetPartAppender : PartAppender<JoinOnExpressionSet>
    {
        #region internals
        private static IDictionary<ConditionalExpressionOperator, string> _conditionalOperatorMap;
        private static IDictionary<ConditionalExpressionOperator, string> ConditionalOperatorMap => _conditionalOperatorMap ?? (_conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators());
        #endregion

        #region methods
        public override void AppendPart(JoinOnExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is null || (expression.LeftArg is null && expression.RightArg is null))
                return;

            if (expression.Negate)
                builder.Appender.Write("NOT (");

            if (expression.LeftArg is object)
            {
                builder.AppendPart(expression.LeftArg, context);
            }
            if (expression.RightArg is object)
            {
                builder.Appender.Write(ConditionalOperatorMap[expression.ConditionalOperator]);
                builder.AppendPart(expression.RightArg, context);
            }

            if (expression.Negate)
                builder.Appender.Write(')');
        }
        #endregion
    }
}
