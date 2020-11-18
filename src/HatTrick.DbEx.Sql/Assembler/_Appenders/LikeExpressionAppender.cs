using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LikeExpressionAppender : ExpressionElementAppender<LikeExpression>
    {
        public override void AppendElement(LikeExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("LIKE ");
            builder.Appender.Write(builder.Parameters.Add(expression.Expression).ParameterName);
        }
    }
}
