using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NewIdFunctionExpressionAppender : ExpressionElementAppender<NewIdFunctionExpression>
    {
        #region methods
        public override void AppendElement(NewIdFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("NEWID()");
        }
        #endregion
    }
}
