using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionPartAppender : PartAppender<AssignmentExpression>
    {
        public override void AppendPart(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart((expression as IDbAssignmentExpressionProvider).Assignee, context);
            builder.Appender.Write(" = ");
            builder.AppendPart((expression as IDbAssignmentExpressionProvider).Assignment, context);
        }
    }
}
