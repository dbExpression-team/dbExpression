using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class UpdateSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string update = Equals(expression.Assign, null) ? string.Empty : builder.AssemblePart<AssignmentExpressionSet>(expression.Assign, overrides);
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<FilterExpressionSet>(expression.Where, overrides);
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.Joins, overrides);
            string ex = Assemble(expression, builder, overrides, update, expression.BaseEntity.ToString("[s].[e]"), where, joins);
            return new SqlStatement(ex, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides, string update, string fromEntity, string where, string joins)
        {
            var appender = builder.CreateAppender();

            appender
                .Indent().Write("UPDATE").LineBreak()
                .Indent().Write(fromEntity).LineBreak()
                .Indent().Write("SET").LineBreak()
                .IndentLevel++.Indent().Write(update).LineBreak()
                .IndentLevel--.Indent().Write("FROM").LineBreak()
                .IndentLevel++.Indent().Write(fromEntity).LineBreak()
                .Indent().Write(joins).LineBreak()
                .IfNotEmpty(where, a =>
                    a.IndentLevel--.Indent().Write("WHERE").LineBreak()
                        .IndentLevel++.Indent().Write(where).LineBreak()
                        .IndentLevel--
                );

            return appender.ToString();

            //return $"{after("UPDATE")}{after(fromEntity)}{after("SET")}{after(update)}{after("FROM")}{after(fromEntity)}{joins}{where}";
        }
        #endregion
    }
}