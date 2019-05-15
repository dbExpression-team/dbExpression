using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetUtcDateFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<GetUtcDateFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as GetUtcDateFunctionExpression, builder, context);

        public void AppendPart(GetUtcDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETUTCDATE()");

            AppendAlias(expression, builder, context);

        }
        #endregion
    }
}
