using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinExpressionSetPartAppender : PartAppender<JoinExpressionSet>
    {        
        public override void AppendPart(JoinExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions == null || !expression.Expressions.Any())
                return;

            foreach (var join in expression.Expressions)
            {
                builder.AppendPart(join, context);
                builder.Appender.LineBreak();
            }
        }
    }
}
