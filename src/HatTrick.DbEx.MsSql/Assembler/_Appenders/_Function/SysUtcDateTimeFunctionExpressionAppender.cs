using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysUtcDateTimeFunctionExpressionAppender : ExpressionElementAppender<SysUtcDateTimeFunctionExpression>
    {
        #region methods
        public override void AppendElement(SysUtcDateTimeFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSUTCDATETIME()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
