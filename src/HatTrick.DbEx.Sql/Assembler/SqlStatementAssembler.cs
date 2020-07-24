using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected virtual void AppendJoinClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendPart(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where?.LeftArg is null && expression.Where?.RightArg is null)
                return;

            builder.Appender.Indent().Write("WHERE").LineBreak()
                .Indentation++;

            builder.AppendPart(expression.Where, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }
        #endregion
    }
}
