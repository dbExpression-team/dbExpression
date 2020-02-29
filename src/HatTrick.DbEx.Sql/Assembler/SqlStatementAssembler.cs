using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected virtual void AppendJoinClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions == null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendPart(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }
        #endregion
    }
}
