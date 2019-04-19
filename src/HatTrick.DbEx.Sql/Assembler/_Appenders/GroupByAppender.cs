using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByAppender : 
        IAssemblyPartAppender<GroupByExpressionSet>,
        IAssemblyPartAppender<GroupByExpression>
    {        
        public void AppendPart(GroupByExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as GroupByExpression, builder, context);

        public void AppendPart(GroupByExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.Expression, context);
        }
    }
}
