using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LiteralExpressionAppender : ExpressionElementAppender<LiteralExpression>
    {
        public override void AppendElement(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.Field is object)
            {
                builder.Appender.Write(
                   builder.Parameters.Add(
                       expression.Expression is null || expression.Expression is DBNull ? DBNull.Value : expression.Expression,
                       context.Field is object ? builder.FindMetadata(context.Field) : null
                   )
                   .Parameter.ParameterName
               );
            }
            else
            {
                if (expression.Expression is null || expression.Expression is DBNull)
                {
                    builder.Appender.Write("NULL");
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression.Expression, expression.Expression.GetType()).ParameterName);
                }
            }
        }
    }
}
