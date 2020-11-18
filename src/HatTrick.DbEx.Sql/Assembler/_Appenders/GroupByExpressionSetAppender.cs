using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByExpressionSetAppender : ExpressionElementAppender<GroupByExpressionSet>
    {        
        public override void AppendElement(GroupByExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var groupBys = expression.Expressions.ToList();
            for (var i = 0; i < groupBys.Count; i++)
            {
                builder.Appender.Indent();

                if (context.Configuration.PrependCommaOnSelectClause && i > 0)
                    builder.Appender.Write(",");

                builder.AppendElement(groupBys[i], context);

                if (!context.Configuration.PrependCommaOnSelectClause && i < groupBys.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }
    }
}
