using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinExpressionSetAppender : ExpressionElementAppender<JoinExpressionSet>
    {        
        public override void AppendElement(JoinExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            foreach (var join in expression.Expressions)
            {
                builder.AppendElement(join, context);
                builder.Appender.LineBreak();
            }
        }
    }
}
