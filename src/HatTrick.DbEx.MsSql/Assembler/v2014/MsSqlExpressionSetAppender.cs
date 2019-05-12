using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler.v2014
{
    public class MsSqlExpressionSetAppender : ExpressionSetAppender
    {
        public override void AppendPart(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClauses(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);

            if (expression.SkipValue.HasValue)
                builder.Appender.Indent().Write("OFFSET ").Write(expression.SkipValue.ToString()).Write(" ROWS").LineBreak();

            if (expression.LimitValue.HasValue)
                builder.Appender.Indent().Write("FETCH FIRST ").Write(expression.LimitValue.ToString()).Write(" ROWS ONLY").LineBreak();
        }
    }
}
