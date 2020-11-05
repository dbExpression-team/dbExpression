using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByExpressionSetPartAppender : PartAppender<GroupByExpressionSet>
    {        
        public override void AppendPart(GroupByExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var groupBys = expression.Expressions.ToList();
            for (var i = 0; i < groupBys.Count; i++)
            {
                builder.Appender.Indent();

                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart(groupBys[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < groupBys.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }
    }
}
