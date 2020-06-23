using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2008
{
    public class MsSqlSelectSqlStatementAssembler : HatTrick.DbEx.MsSql.Assembler.MsSqlSelectSqlStatementAssembler
    {
        protected override void AssembleSelectStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.SkipValue.HasValue && !expression.LimitValue.HasValue)
            {
                //no  paging, so no special handling required
                base.AssembleSelectStatement(expression, builder, context);
            }
            else if (!(expression.Select as IDbExpressionIsDistinctProvider).IsDistinct) //no distinct, return standard CTE for page
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
