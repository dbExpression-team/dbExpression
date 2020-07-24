using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("DELETE").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendPart(expression.BaseEntity, context);
            builder.Appender.LineBreak();

            builder.Appender.Indentation--.Indent().Write("FROM").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendPart(expression.BaseEntity, context);
            builder.Appender.LineBreak();
            builder.Appender.Indentation--;

            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }
        #endregion
    }
}