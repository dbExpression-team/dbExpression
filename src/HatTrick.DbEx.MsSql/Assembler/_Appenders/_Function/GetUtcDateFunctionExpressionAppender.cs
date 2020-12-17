using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetUtcDateFunctionExpressionAppender : ExpressionElementAppender<GetUtcDateFunctionExpression>
    {
        #region methods
        public override void AppendElement(GetUtcDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETUTCDATE()");
        }
        #endregion
    }
}
