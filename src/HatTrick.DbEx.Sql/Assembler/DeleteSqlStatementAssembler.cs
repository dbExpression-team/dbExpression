using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string where = expression.Where == null ? string.Empty : builder.AssemblePart<FilterExpressionSet>(expression.Where, overrides);
            string joins = expression.Joins == null ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.Joins, overrides);
            string ex = Assemble(expression, builder, overrides, expression.BaseEntity.ToString("[s].[e]"), where, joins);
            return new SqlStatement(ex, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides, string fromEntity, string where, string joins)
        {
            var appender = builder.CreateAppender();

            appender.Write("DELETE").LineBreak()
                .Indentation++.Indent().Write(fromEntity).LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent().Write(fromEntity).LineBreak()
                .Indent().Write(joins).LineBreak()
                .IfNotEmpty(where, a =>
                    a.Indentation--.Indent().Write("WHERE").LineBreak()
                        .Indentation++.Indent().Write(where).LineBreak()
                        .Indentation--
                );

            return appender.ToString();
            //return $"{after("DELETE")}{after(fromEntity)}{after("FROM")}{after(fromEntity)}{joins}{where}";
        }
        #endregion
    }
}