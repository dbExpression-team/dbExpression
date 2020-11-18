using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionAppender : ExpressionElementAppender<AssignmentExpression>
    {
        public override void AppendElement(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var field = (expression as IAssignmentExpressionProvider).Assignee;

            builder.AppendElement(field, context);
            builder.Appender.Write(" = ");

            context.PushField(field);
            try
            {
                builder.AppendElement((expression as IAssignmentExpressionProvider).Assignment, context);
            }
            finally
            {
                context.PopField();
            }
        }
    }
}
