using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlSelectSqlStatementAssembler : SelectSqlStatementAssembler
    {
        protected virtual void AssembleMsSqlCTESelectStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //start CTE
            builder.Appender.Indent().Write("SELECT").LineBreak()
                .Indentation++
                .Indent().Write("*").LineBreak()
                .Indentation--
                .Indent().Write("FROM (").LineBreak()
                .Indentation++;

            context.PushAppendStyle(EntityExpressionAppendStyle.None);
            AppendSelectClause(expression, builder, context);
            context.PopAppendStyles();

            //add windowing function
            if (context.Configuration.PrependCommaOnSelectClause)
                builder.Appender.Write(", ");
            builder.Appender.Indentation++.Indent().Write("ROW_NUMBER() OVER (");

            var orderBys = expression.OrderBy.Expressions.ToList();
            for (var i = 0; i < orderBys.Count; i++)
            {
                builder.Appender.Indent();

                context.PushAppendStyle(EntityExpressionAppendStyle.None);
                builder.AppendElement(orderBys[i], context);
                context.PopAppendStyles();

                if (i < orderBys.Count - 1)
                    builder.Appender.Write(", ");
            }
            builder.Appender.Write(") AS [__index]").LineBreak();

            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);

            //end CTE
            builder.Appender.Indent().Write("AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write((expression.BaseEntity as ISqlMetadataIdentifier).Identifier)
                    .Write(context.Configuration.IdentifierDelimiter.End)
                    .LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++
                    .Write("[__index] BETWEEN ")
                    .Write(builder.Parameters.Add((expression.Skip ?? 0) + 1).ParameterName)
                    .Write(" AND ")
                    .Write(builder.Parameters.Add((expression.Skip ?? 0 + expression.Limit ?? expression.Skip ?? -1) + 1).ParameterName)
                    .LineBreak()
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write("[__index]");

            return;
        }

        protected virtual void AssembleMsSqlDistinctCTESelectStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //expression is marked as DISTINCT and uses paging, must perform a subselect with the distinct prior
            //to using ROW_NUMBER as inclusion of ROW_NUMBER with DISTINCT uses the generated index of the row
            //as part of the DISTINCT, effectively disabling the distinct

            //original expression set will be "wrapped" twice to ensure distinct works with ROWNUMBER(), generate and set as "ghost" aliases with levels "out-dented" from original current depth
            var innerTableAlias = builder.GenerateAlias();
            var outerTableAlias = builder.GenerateAlias();

            builder.Appender.Write("SELECT ").LineBreak()
                .Indentation++;

            //append the select list, which is the "final" select from the CTE
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            try
            {
                builder.AppendElement(expression.Select, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender
                .Indentation--
                .Indent().Write("FROM (").LineBreak();

            //append select for "inner" which has the ROW_NUMBER() function for paging
            builder.Appender
                .Indentation++
                .Indent()
                .Write("SELECT ").LineBreak()
                .Indentation++;

            //append the select list
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            try
            {
                builder.AppendElement(expression.Select, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            //append the function providing the windowed index
            builder.Appender
                .Indent().Write(", ROW_NUMBER() OVER (ORDER BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            try
            {
                builder.AppendElement(expression.OrderBy, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(context.Configuration.IdentifierDelimiter.Begin).Write("_index").Write(context.Configuration.IdentifierDelimiter.End).LineBreak()
                .Indentation--.Indent().Write("FROM (").LineBreak();

            builder.Appender
                .Indentation++;

            //now append the "original" select statement
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);

            builder.Appender
                .Indentation--
                .Indent().Write(") AS ").Write(context.Configuration.IdentifierDelimiter.Begin).Write(innerTableAlias).Write(context.Configuration.IdentifierDelimiter.End).LineBreak();

            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End).LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++.Indent().Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End)
                    .Write(".").Write(context.Configuration.IdentifierDelimiter.Begin).Write("_index").Write(context.Configuration.IdentifierDelimiter.End).Write(" BETWEEN ")
                    .Write(builder.Parameters.Add((expression.Skip ?? 0) + 1).ParameterName);

            if (expression.Limit.HasValue)
            {
                builder.Appender
                    .Write(" AND ")
                    .Write(builder.Parameters.Add((expression.Skip ?? 0) + expression.Limit.Value + 1).ParameterName)
                    .LineBreak();
            }
            builder.Appender
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End).Write(".").Write(context.Configuration.IdentifierDelimiter.Begin).Write("_index").Write(context.Configuration.IdentifierDelimiter.End).LineBreak();

        }
    }
}
