using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class GetDateFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<GetDateFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as GetDateFunctionExpression, builder, context);

        public void AppendPart(GetDateFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("GETDATE()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
