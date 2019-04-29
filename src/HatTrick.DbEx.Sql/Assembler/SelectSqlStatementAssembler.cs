using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectSqlStatementAssembler : 
        SqlStatementAssembler
    {
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart<ExpressionSet>(expression, context);
        }
    }
}