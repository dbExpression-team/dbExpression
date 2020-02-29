using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeFunctionAppender : PartAppender<SysDateTimeFunctionExpression>
    {
        #region methods
        public override void AppendPart(SysDateTimeFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIME()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
