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
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var inserts = expression.Expressions.ToList();
            for (var i = 0; i < inserts.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendPart(inserts[i], context);
                if (i < inserts.Count - 1)
                {
                    builder.Appender.Write(",").LineBreak();
                }
            }
        }
    }
}
