using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2005
{
    public class MsSqlSelectSqlStatementAssembler : HatTrick.DbEx.MsSql.Assembler.MsSqlSelectSqlStatementAssembler
    {
        protected override void AssembleStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.Skip.HasValue && !expression.Limit.HasValue)
            {
                //no  paging, so no special handling required
                base.AssembleStatement(expression, builder, context);
            }
            else if (!(expression.Select as IExpressionIsDistinctProvider).IsDistinct) //no distinct, return standard CTE for page
            {
                AssembleMsSqlCTESelectStatement(expression, builder, context);
            }
            else
            {
                AssembleMsSqlDistinctCTESelectStatement(expression, builder, context);
            }
        }
    }
}
