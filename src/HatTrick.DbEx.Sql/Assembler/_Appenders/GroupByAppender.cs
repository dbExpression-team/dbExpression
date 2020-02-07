using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GroupByAppender : 
        ExpressionAppender,
        IAssemblyPartAppender<GroupByExpressionSet>,
        IAssemblyPartAppender<GroupByExpression>
    {        
        public void AppendPart(GroupByExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as GroupByExpression, builder, context);

        public void AppendPart(GroupByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression, context);
        }
    }
}
