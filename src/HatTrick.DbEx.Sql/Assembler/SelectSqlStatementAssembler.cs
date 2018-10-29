using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using HatTrick.DbEx.Sql.Extensions.Assembler;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectSqlStatementAssembler : SqlStatementAssembler, IDbExpressionAssemblyPartAssembler<ExpressionSet>
    {
        public string AssemblePart(object part, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            return AssembleStatement((ExpressionSet)part, builder, overrides).ExecutionCommand;
        }

        public string AssemblePart(ExpressionSet part, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            return AssembleStatement(part, builder, overrides).ExecutionCommand;
        }

        public override SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            string joins = expression.Joins == null ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.Joins, overrides);
            string select = expression.Select == null ? string.Empty : builder.AssemblePart<SelectExpressionSet>(expression.Select, overrides);
            string where = expression.Where == null ? string.Empty : builder.AssemblePart<WhereExpressionSet>(expression.Where, overrides);
            string groupBy = expression.GroupBy == null ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.GroupBy, overrides);
            string having = expression.Having == null ? string.Empty : builder.AssemblePart<HavingExpression>(expression.Having, overrides);
            string orderBy = expression.OrderBy == null ? string.Empty : builder.AssemblePart<OrderByExpressionSet>(expression.OrderBy, overrides);

            if (expression.BaseEntity.IsAliased && !overrides.EntityAliases.Contains(expression.BaseEntity))
                overrides.EntityAliases.SetAliasForEntity(expression.BaseEntity.AliasName, expression.BaseEntity);

            string from = builder.AssemblePart<EntityExpression>(expression.BaseEntity, overrides);

            string sql = Assemble(
                expression,
                builder,
                overrides,
                select,
                expression.Distinct ? "DISTINCT " : string.Empty,
                from,
                where,
                joins,
                groupBy,
                having,
                orderBy
            );

            return new SqlStatement(sql, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBy)
        {
            var appender = builder.CreateAppender();

            appender.Write("SELECT").LineBreak()
                .IfNotEmpty(distinct, a => a.Indent().Write(distinct).LineBreak())
                .Indentation++.Indent().Write(select).LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent().Write(fromEntity).LineBreak()
                .Indent().Write(joins).LineBreak()
                .IfNotEmpty(where, a =>
                    a.Indentation--.Indent().Write("WHERE").LineBreak()
                        .Indentation++.Indent().Write(where).LineBreak()
                )
                .IfNotEmpty(groupBy, a =>
                    a.Indentation--.Indent().Write("GROUP BY").LineBreak()
                        .Indentation++.Indent().Write(groupBy).LineBreak()
                )
                .IfNotEmpty(having, a =>
                    a.Indentation--.Indent().Write("HAVING").LineBreak()
                        .Indentation++.Indent().Write(having).LineBreak()
                )
                .IfNotEmpty(orderBy, a =>
                    a.Indentation--.Indent().Write("ORDER BY").LineBreak()
                        .Indentation++.Indent().Write(orderBy).LineBreak()
                );

            return appender.ToString();

            //return $"{overrides.FormatEndOfSegment("SELECT")}{overrides.FormatEndOfSegment(distinct)}{overrides.FormatEndOfSegment(select)}{overrides.FormatEndOfSegment("FROM")}{overrides.FormatEndOfSegment(fromEntity)}{joins}{where}{groupBy}{having}{orderBy}";
        }
    }
}