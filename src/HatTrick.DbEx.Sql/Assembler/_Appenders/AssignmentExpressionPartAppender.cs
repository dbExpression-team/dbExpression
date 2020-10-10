using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionPartAppender : PartAppender<AssignmentExpression>
    {
        public override void AppendPart(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var field = (expression as IAssignmentExpressionProvider).Assignee;

            builder.AppendPart(field, context);
            builder.Appender.Write(" = ");

            context.PushField(field);
            try
            {
                builder.AppendPart((expression as IAssignmentExpressionProvider).Assignment, context);
            }
            finally
            {
                context.PopField();
            }
        }
    }
}
