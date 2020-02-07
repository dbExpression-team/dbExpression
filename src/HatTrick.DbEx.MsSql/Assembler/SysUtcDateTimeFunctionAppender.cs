using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysUtcDateTimeFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<SysUtcDateTimeFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as SysUtcDateTimeFunctionExpression, builder, context);

        public void AppendPart(SysUtcDateTimeFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSUTCDATETIME()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
