using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectAppender : 
        IAssemblyPartAppender<SelectExpressionSet>,
        IAssemblyPartAppender<SelectExpression>
    {
        public void AppendPart(SelectExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as SelectExpression, builder, context);

        public void AppendPart(SelectExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.Expression, context);
            var alias = (expression as IAliasable)?.Alias;
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender.Write(" AS ");
                builder.Appender.Write(alias);
            }
        }
    }
}
