using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CurrentTimestampFunctionExpressionPartAppender : PartAppender<CurrentTimestampFunctionExpression>
    {
        #region methods
        public override void AppendPart(CurrentTimestampFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("CURRENT_TIMESTAMP");

            AppendAlias(expression, builder, context);

        }
        #endregion
    }
}
