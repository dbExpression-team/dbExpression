using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetDateFunctionAppender : PartAppender<GetDateFunctionExpression>
    {
        #region methods
        public override void AppendPart(GetDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETDATE()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
