using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssignmentExpressionPartAppender : PartAppender<AssignmentExpression>
    {
        public override void AppendPart(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression.LeftPart, context);
            builder.Appender.Write(" = ");
            builder.Appender.Write(builder.Parameters.Add(expression.Expression.RightPart, context.Field).Parameter.ParameterName);
        }
    }
}
