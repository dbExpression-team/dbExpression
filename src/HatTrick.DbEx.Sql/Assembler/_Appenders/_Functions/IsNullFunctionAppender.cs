using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class IsNullFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<IsNullFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as IsNullFunctionExpression, builder, context);

        public void AppendPart(IsNullFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("ISNULL(");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(", ");
            builder.AppendPart(expression.Value, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
