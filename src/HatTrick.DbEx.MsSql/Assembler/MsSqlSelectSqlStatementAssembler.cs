#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlSelectSqlStatementAssembler : SelectSqlStatementAssembler
    {
        protected override void AssembleStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            base.AssembleStatement(expression, builder, context);
            if (expression.Offset.HasValue)
            {
                var param = builder.Parameters.CreateInputParameter(expression.Offset.Value, context);
                builder.Parameters.AddParameter(param);
                builder.Appender
                    .Indentation++
                    .Indent()
                    .Write("OFFSET ")
                    .Write(param.Parameter.ParameterName)
                    .Write(" ROWS")
                    .LineBreak()
                    .Indentation--;
            }
            if (expression.Limit.HasValue)
            {
                var param = builder.Parameters.CreateInputParameter(expression.Limit.Value, context);
                builder.Parameters.AddParameter(param);
                builder.Appender
                    .Indentation++
                    .Indent()
                    .Write("FETCH NEXT ")
                    .Write(param.Parameter.ParameterName)
                    .Write(" ROWS ONLY")
                    .LineBreak()
                    .Indentation--;
            }
        }

        protected virtual void AssembleMsSqlCTESelectStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //start CTE
            builder.Appender.Indent().Write("SELECT").LineBreak()
                .Indentation++
                .Indent().Write("*").LineBreak()
                .Indentation--
                .Indent().Write("FROM (").LineBreak()
                .Indentation++;

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
            try
            {
                AppendSelectClause(expression, builder, context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            //add windowing function
            if (context.Configuration.PrependCommaOnSelectClause)
                builder.Appender.Write(", ");
            builder.Appender.Indentation++.Indent().Write("ROW_NUMBER() OVER (");

            var orderBys = expression.OrderBy.Expressions.ToList();
            for (var i = 0; i < orderBys.Count; i++)
            {
                builder.Appender.Indent();

                context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
                try
                {
                    builder.AppendElement(orderBys[i], context);
                }
                finally
                {
                    context.PopEntityAppendStyle();
                }

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
            var offsetParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + 1, context);
            builder.Parameters.AddParameter(offsetParam);
            var limitParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0 + expression.Limit ?? expression.Offset ?? -1) + 1, context);
            builder.Parameters.AddParameter(limitParam);

            builder.Appender.Indent().Write("AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write((expression.BaseEntity as ISqlMetadataIdentifierProvider).Identifier)
                    .Write(context.Configuration.IdentifierDelimiter.End)
                    .LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++
                    .Write("[__index] BETWEEN ")
                    .Write(offsetParam.Parameter.ParameterName)
                    .Write(" AND ")
                    .Write(limitParam.Parameter.ParameterName)
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

            var offsetParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + 1, context);
            builder.Parameters.AddParameter(offsetParam);
            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End).LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++.Indent().Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End)
                    .Write(".").Write(context.Configuration.IdentifierDelimiter.Begin).Write("_index").Write(context.Configuration.IdentifierDelimiter.End).Write(" BETWEEN ")
                    .Write(offsetParam.Parameter.ParameterName);

            if (expression.Limit.HasValue)
            {
                var limitParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + expression.Limit.Value + 1, context);
                builder.Parameters.AddParameter(limitParam);
                builder.Appender
                    .Write(" AND ")
                    .Write(limitParam.Parameter.ParameterName)
                    .LineBreak();
            }
            builder.Appender
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write(context.Configuration.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.Configuration.IdentifierDelimiter.End).Write(".").Write(context.Configuration.IdentifierDelimiter.Begin).Write("_index").Write(context.Configuration.IdentifierDelimiter.End).LineBreak();

        }
    }
}
