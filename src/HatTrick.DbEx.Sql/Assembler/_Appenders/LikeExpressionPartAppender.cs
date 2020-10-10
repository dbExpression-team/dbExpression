using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LikeExpressionPartAppender : PartAppender<LikeExpression>
    {
        public override void AppendPart(LikeExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("LIKE ");
            builder.Appender.Write(builder.Parameters.Add(expression.Expression).ParameterName);
        }
    }
}
