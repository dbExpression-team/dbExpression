using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CurrentTimestampFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<CurrentTimestampFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as CurrentTimestampFunctionExpression, builder, context);

        public void AppendPart(CurrentTimestampFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("CURRENT_TIMESTAMP");

            AppendAlias(expression, builder, context);

        }
        #endregion
    }
}
