using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeOffsetFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<SysDateTimeOffsetFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as SysDateTimeOffsetFunctionExpression, builder, context);

        public void AppendPart(SysDateTimeOffsetFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIMEOFFSET()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
