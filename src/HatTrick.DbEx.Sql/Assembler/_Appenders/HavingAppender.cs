using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingAppender : IAssemblyPartAppender<HavingExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
           => AppendPart(expression as HavingExpression, builder, context);

        public void AppendPart(HavingExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
            => builder.AppendPart(expression.Expression, context);
    }
}
