using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingAppender : 
        ExpressionAppender,
        IAssemblyPartAppender<HavingExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
           => AppendPart(expression as HavingExpression, builder, context);

        public void AppendPart(HavingExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent();
            builder.AppendPart(expression.Expression, context);
        }
    }
}
