using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class IsNullFunctionExpressionPartAppender : PartAppender<IsNullFunctionExpression>
    {
        #region methods
        public override void AppendPart(IsNullFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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
