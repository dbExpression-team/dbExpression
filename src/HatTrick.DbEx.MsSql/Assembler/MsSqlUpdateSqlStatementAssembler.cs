using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlUpdateSqlStatementAssembler : UpdateSqlStatementAssembler
    {
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            base.AssembleStatement(expression, builder, context);
            builder.Appender.LineBreak().Write("; SELECT @@ROWCOUNT");
        }
    }
}
