using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionSetAppender : ExpressionElementAppender<AssignmentExpressionSet>
    {
        public override void AppendElement(AssignmentExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var inserts = expression.Expressions.ToList();
            for (var i = 0; i < inserts.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendElement(inserts[i], context);
                if (i < inserts.Count - 1)
                {
                    builder.Appender.Write(",").LineBreak();
                }
            }
        }
    }
}
