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
            string insert = Equals(expression.Insert, null) ? string.Empty : builder.AssemblePart<InsertExpressionSet>(expression.Insert, overrides);
            //TODO: use part assembler to build base entity
            insert = Assemble(expression, overrides, expression.BaseEntity.ToString("[s].[e]"), insert);
            return new SqlStatement(insert, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, AssemblerOverrides overrides, string entity, string insert)
             => $"INSERT INTO {entity} {insert};";

        #endregion
    }
}