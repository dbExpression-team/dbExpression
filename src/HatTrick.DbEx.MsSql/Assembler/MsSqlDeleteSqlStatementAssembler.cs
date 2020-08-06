using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlDeleteSqlStatementAssembler : DeleteSqlStatementAssembler
    {
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            base.AssembleStatement(expression, builder, context);
            builder.Appender.LineBreak().Write("; SELECT @@ROWCOUNT");
        }
    }
}
