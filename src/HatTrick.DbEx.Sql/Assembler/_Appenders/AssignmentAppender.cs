using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class UpdateClauseAssembler : 
        IAssemblyPartAppender<AssignmentExpressionSet>,
        IAssemblyPartAppender<AssignmentExpression>
    {
        public void AppendPart(AssignmentExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as AssignmentExpression, builder, context);

        public void AppendPart(AssignmentExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.Expression.LeftPart, context);
            builder.Appender.Write(" = ");
            builder.Appender.Write(builder.Parameters.Add(expression.Expression.RightPart, expression.Expression.RightPart.GetType()).ParameterName);
        }
    }
}
