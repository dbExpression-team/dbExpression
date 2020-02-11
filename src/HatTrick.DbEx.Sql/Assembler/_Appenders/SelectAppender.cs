using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectAppender : 
        ExpressionAppender,
        IAssemblyPartAppender<SelectExpressionSet>,
        IAssemblyPartAppender<SelectExpression>
    {
        public void AppendPart(SelectExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder.");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as SelectExpression, builder, context);

        public void AppendPart(SelectExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression, context);

            if (expression is IDbExpressionAliasProvider aliasable)
            {
                AppendAlias(aliasable, builder, context);
            }
        }
    }
}
