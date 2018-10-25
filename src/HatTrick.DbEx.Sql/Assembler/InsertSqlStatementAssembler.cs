using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string insert = expression.Insert == null ? string.Empty : builder.AssemblePart<InsertExpressionSet>(expression.Insert, overrides);

            string from = builder.AssemblePart<EntityExpression>(expression.BaseEntity, overrides);

            insert = Assemble(expression, overrides, from, insert);

            return new SqlStatement(insert, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, AssemblerOverrides overrides, string entity, string insert)
             => $"INSERT INTO {entity} {insert};";

        #endregion
    }
}