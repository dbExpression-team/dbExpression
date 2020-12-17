using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SysDateTimeFunctionExpressionAppender : ExpressionElementAppender<SysDateTimeFunctionExpression>
    {
        #region methods
        public override void AppendElement(SysDateTimeFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("SYSDATETIME()");
        }
        #endregion
    }
}
