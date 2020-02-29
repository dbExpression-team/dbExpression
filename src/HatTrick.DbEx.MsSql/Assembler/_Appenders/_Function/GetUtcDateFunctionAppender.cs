using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetUtcDateFunctionAppender : PartAppender<GetUtcDateFunctionExpression>
    {
        #region methods
        public override void AppendPart(GetUtcDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETUTCDATE()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
