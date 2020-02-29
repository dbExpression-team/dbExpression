using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingExpressionPartAppender : PartAppender<HavingExpression>
    {
        public override void AppendPart(HavingExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent();
            builder.AppendPart(expression.Expression, context);
        }
    }
}
