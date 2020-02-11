using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CastFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<CastFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as CastFunctionExpression, builder, context);

        public void AppendPart(CastFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("CAST(");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(" AS ");
            builder.Appender.Write(expression.ConvertToSqlDbType.ToString());
            if (expression.Size.HasValue)
            {
                builder.Appender.Write("(");
                builder.Appender.Write(expression.Size.Value.ToString());
                builder.Appender.Write(")");
            }
            else
            {
                if (expression.Precision.HasValue)
                {
                    builder.Appender.Write("(");
                    builder.Appender.Write(expression.Precision.Value.ToString());
                    if (expression.Scale.HasValue)
                    {
                        builder.Appender.Write(", ");
                        builder.Appender.Write(expression.Scale.Value.ToString());
                    }
                    builder.Appender.Write(")");
                }
            }
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
