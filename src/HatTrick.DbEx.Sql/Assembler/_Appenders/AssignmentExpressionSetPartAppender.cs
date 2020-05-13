using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionSetPartAppender : PartAppender<AssignmentExpressionSet>
    {
        public override void AppendPart(AssignmentExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions == null || !expression.Expressions.Any())
                return;

            for (var i = 0; i < expression.Expressions.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendPart(expression.Expressions[i], context);
                if (i < expression.Expressions.Count - 1)
                {
                    builder.Appender.Write(",").LineBreak();
                }
            }
        }
    }
}
