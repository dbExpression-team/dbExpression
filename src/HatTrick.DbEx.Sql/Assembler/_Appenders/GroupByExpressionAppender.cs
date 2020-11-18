using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByExpressionAppender : ExpressionElementAppender<GroupByExpression>
    {        
        public override void AppendElement(GroupByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.AppendElement(expression.Expression, context);
    }
}
