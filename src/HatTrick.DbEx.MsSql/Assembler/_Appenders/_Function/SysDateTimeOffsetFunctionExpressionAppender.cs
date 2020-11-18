using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeOffsetFunctionExpressionAppender : ExpressionElementAppender<SysDateTimeOffsetFunctionExpression>
    {
        #region methods
        public override void AppendElement(SysDateTimeOffsetFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIMEOFFSET()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
