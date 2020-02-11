using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class NewIdFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<NewIdFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as NewIdFunctionExpression, builder, context);

        public void AppendPart(NewIdFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("NEWID()");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
