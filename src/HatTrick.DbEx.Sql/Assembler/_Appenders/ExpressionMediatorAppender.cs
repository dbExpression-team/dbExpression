using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionMediatorAppender :
        ExpressionAppender,
        IAssemblyPartAppender<ExpressionMediator>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.AppendPart((expression as ExpressionMediator).Expression, context);

        public void AppendPart(ExpressionMediator expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression, context);

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
