using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeOffsetFunctionAppender : PartAppender<SysDateTimeOffsetFunctionExpression>
    {
        #region methods
        public override void AppendPart(SysDateTimeOffsetFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIMEOFFSET()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
