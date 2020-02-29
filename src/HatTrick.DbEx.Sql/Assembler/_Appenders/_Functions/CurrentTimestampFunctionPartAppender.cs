using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CurrentTimestampFunctionPartAppender : PartAppender<CurrentTimestampFunctionExpression>
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
