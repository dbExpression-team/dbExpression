using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<SysDateTimeFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as SysDateTimeFunctionExpression, builder, context);

        public void AppendPart(SysDateTimeFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIME()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
