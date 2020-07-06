using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected virtual void AppendJoinClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions == null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendPart(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where?.LeftArg == null && expression.Where?.RightArg == default)
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
