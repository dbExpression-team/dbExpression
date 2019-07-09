using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("DELETE").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendPart<EntityExpression>(expression.BaseEntity, context);
            builder.Appender.LineBreak();

            builder.Appender.Indentation--.Indent().Write("FROM").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendPart<EntityExpression>(expression.BaseEntity, context);
            builder.Appender.LineBreak();
            builder.Appender.Indentation--;

            if (expression.Joins != null)
            {
                builder.Appender.Indentation++;
                builder.Appender.Indent();
                foreach (var join in expression.Joins.Expressions)
                    builder.AppendPart<JoinExpression>(join, context);
                builder.Appender.LineBreak();
                builder.Appender.Indentation--;
            }

            if (expression.Where != null)
            {
                builder.Appender.Indent().Write("WHERE").LineBreak();
                builder.Appender.Indentation++;
                builder.AppendPart<FilterExpressionSet>(expression.Where, context);
                builder.Appender.LineBreak();
                builder.Appender.Indentation--;
            }
        }
        #endregion
    }
}