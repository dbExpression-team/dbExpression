using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByExpressionPartAppender : PartAppender<GroupByExpression>
    {        
        public override void AppendPart(GroupByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.AppendPart(expression.Expression, context);
    }
}
