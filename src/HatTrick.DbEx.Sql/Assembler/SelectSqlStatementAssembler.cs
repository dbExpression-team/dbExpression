using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;

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
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.Joins, overrides);
            string select = Equals(expression.Select, null) ? string.Empty : builder.AssemblePart<SelectExpressionSet>(expression.Select, overrides);
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<WhereExpressionSet>(expression.Where, overrides);
            string groupBy = Equals(expression.GroupBy, null) ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.GroupBy, overrides);
            string having = Equals(expression.Having, null) ? string.Empty : builder.AssemblePart<HavingExpression>(expression.Having, overrides);
            string orderBy = Equals(expression.OrderBy, null) ? string.Empty : builder.AssemblePart<OrderByExpressionSet>(expression.OrderBy, overrides);

            string sql = Assemble(
                expression,
                builder,
                select,
                expression.Distinct ? "DISTINCT " : string.Empty,
                expression.BaseEntity.ToString("[s].[e]"),
                where,
                joins,
                groupBy,
                having,
                orderBy
            );

            return new SqlStatement(sql, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        public string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            throw new System.NotImplementedException();
        }

        protected virtual string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBy)
        {
            string after(string s) => s.SpaceAfter().NewLineAfter(DbExpressionConfiguration.Minify);

            if (!string.IsNullOrWhiteSpace(distinct))
                distinct = after(distinct);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            if (!string.IsNullOrWhiteSpace(groupBy))
                groupBy = after("GROUP BY") + after(groupBy);

            if (!string.IsNullOrWhiteSpace(having))
                having = after("HAVING") + after(having);

            if (!string.IsNullOrWhiteSpace(orderBy))
                orderBy = after("ORDER BY") + orderBy;

            return $"{after("SELECT")}{distinct}{after(select)}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}{orderBy}";
        }
    }
}