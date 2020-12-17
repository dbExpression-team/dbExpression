using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetDateFunctionExpressionAppender : ExpressionElementAppender<GetDateFunctionExpression>
    {
        #region methods
        public override void AppendElement(GetDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETDATE()");
        }
        #endregion
    }
}
