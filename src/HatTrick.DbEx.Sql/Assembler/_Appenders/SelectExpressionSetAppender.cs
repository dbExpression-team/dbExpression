using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionSetAppender : ExpressionElementAppender<SelectExpressionSet>
    {        
        public override void AppendElement(SelectExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var selects = expression.Expressions.ToList();
            for (var i = 0; i < selects.Count; i++)
            {
                builder.Appender.Indent();
                if (context.Configuration.PrependCommaOnSelectClause && i > 0)
                {
                    builder.Appender.Write(",");
                }

                builder.AppendElement(selects[i], context);

                if (!context.Configuration.PrependCommaOnSelectClause && i < selects.Count - 1)
                {
                    builder.Appender.Write(",");
                }

                builder.Appender.LineBreak();
            }
        }
    }
}
