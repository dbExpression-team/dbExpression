using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByExpressionAppender : ExpressionElementAppender<GroupByExpression>
    {
        public override void AppendElement(GroupByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var originalTryShareParameterSetting = context.TrySharingExistingParameter;
            context.TrySharingExistingParameter = true;
            try
            {
                builder.AppendElement(expression.Expression, context);
            }
            finally
            {
                context.TrySharingExistingParameter = originalTryShareParameterSetting;
            }
        }
    }
}
