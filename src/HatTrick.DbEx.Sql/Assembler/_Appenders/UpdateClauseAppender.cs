using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class UpdateClauseAssembler : 
        ExpressionAppender,
        IAssemblyPartAppender<AssignmentExpressionSet>,
        IAssemblyPartAppender<AssignmentExpression>
    {
        public void AppendPart(AssignmentExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as AssignmentExpression, builder, context);

        public void AppendPart(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression.LeftPart, context);
            builder.Appender.Write(" = ");
            builder.Appender.Write(builder.Parameters.Add(expression.Expression.RightPart, context.Field).Parameter.ParameterName);
        }
    }
}
