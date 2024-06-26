#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using System.Linq;

namespace DbExpression.MsSql.Assembler
{
    public class MsSqlSelectQueryExpressionAppender : SelectQueryExpressionAppender
    {
        public override void AppendElement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            base.AppendElement(expression, builder, context);
            if (expression.Offset.HasValue)
            {
                var param = builder.Parameters.CreateInputParameter(expression.Offset.Value, context);
                builder.Parameters.AddParameter(param);
                builder.Appender
                    .Indentation++
                    .LineBreak()
                    .Indent()
                    .Write("OFFSET ")
                    .Write(param.Parameter.ParameterName)
                    .Write(" ROWS")
                    .Indentation--;
            }
            if (expression.Limit.HasValue)
            {
                var param = builder.Parameters.CreateInputParameter(expression.Limit.Value, context);
                builder.Parameters.AddParameter(param);
                builder.Appender
                    .LineBreak()
                    .Indentation++
                    .Indent()
                    .Write("FETCH NEXT ")
                    .Write(param.Parameter.ParameterName)
                    .Write(" ROWS ONLY")
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
            builder.Appender.Indentation++;
            if (context.PrependCommaOnSelectClause)
                builder.Appender.LineBreak().Indent().Write(',');
            else
                builder.Appender.Write(',').LineBreak().Indent();
            builder.Appender.Write("ROW_NUMBER() OVER (");

            var orderBys = expression.OrderBy?.Expressions?.ToList();
            if (orderBys is not null)
            {
                builder.Appender.Write("ORDER BY ");
                for (var i = 0; i < orderBys.Count; i++)
                {
                    //builder.Appender.Indent();

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
                        builder.Appender.Write(',');
                }
            }
            builder.Appender.Write(") AS [__index]").Indentation--;

            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);

            //end CTE
            var offsetParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + 1, context);
            builder.Parameters.AddParameter(offsetParam);
            var limitParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + (expression.Limit ?? expression.Offset), context);

            builder.Parameters.AddParameter(limitParam);

            builder.Appender.Indentation--.LineBreak()
                    .Write(") AS ")
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write(builder.GetPlatformName((expression.From!.Expression as Table)!))
                    .Write(context.IdentifierDelimiter.End)
                    .LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++
                    .Indent()
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
            var select_list = expression.Select.Expressions.ToList();
            for (var i = 0; i < select_list.Count; i++)
            {
                var select = select_list[i];
                context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
                try
                {
                    builder.Appender.Indent();
                    if (context.PrependCommaOnSelectClause && i > 0)
                        builder.Appender.Write(",");
                    builder.Appender.Write(context.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.IdentifierDelimiter.End).Write(".");
                    try
                    {
                        context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);
                        builder.AppendElement(select, context);
                    }
                    finally
                    {
                        context.PopFieldAppendStyle();
                    }
                    if (!context.PrependCommaOnSelectClause && i < select_list.Count - 1)
                        builder.Appender.Write(",");
                    builder.Appender.LineBreak();
                }
                finally
                {
                    context.PopEntityAppendStyle();
                }
            }

            builder.Appender
                .Indentation--
                .Indent().Write("FROM (").LineBreak();

            builder.Appender.Indentation++;
            AppendSelectClause(expression, builder, context, EntityExpressionAppendStyle.None, false, null);

            //append the function providing the windowed index
            builder.Appender
                .Indentation++
                .If(!context.PrependCommaOnSelectClause, a => a.Write(','))
                .LineBreak()
                .Indent()
                .If(context.PrependCommaOnSelectClause, a => a.Write(','))
                .Write("ROW_NUMBER() OVER (ORDER BY")
                .LineBreak()
                .Indentation++;

            //append the order by list, which is the "final" select from the CTE
            var order_by_list = expression.OrderBy?.Expressions?.ToList();
            if (order_by_list is not null)
            {
                for (var i = 0; i < order_by_list.Count; i++)
                {
                    var order_by = order_by_list[i];
                    context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
                    try
                    {
                        builder.Appender.Indent();
                        if (context.PrependCommaOnSelectClause && i > 0)
                            builder.Appender.Write(",");
                        builder.Appender.Write(context.IdentifierDelimiter.Begin).Write(innerTableAlias).Write(context.IdentifierDelimiter.End).Write(".");
                        builder.AppendElement(order_by, context);
                        if (!context.PrependCommaOnSelectClause && i < order_by_list.Count - 1)
                            builder.Appender.Write(",");
                        builder.Appender.LineBreak();
                    }
                    finally
                    {
                        context.PopEntityAppendStyle();
                    }
                }
            }

            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(context.IdentifierDelimiter.Begin).Write("_index").Write(context.IdentifierDelimiter.End).LineBreak()
                .Indentation--.Indent().Write("FROM (").LineBreak();

            builder.Appender
                .Indentation++;

            //now append the "original" select statement
            AppendSelectClause(expression, builder, context, EntityExpressionAppendStyle.Alias, expression.Distinct, expression.Top);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);

            builder.Appender
                .Indentation--
                .LineBreak()
                .Indent().Write(") AS ").Write(context.IdentifierDelimiter.Begin).Write(innerTableAlias).Write(context.IdentifierDelimiter.End).LineBreak();

            builder.Appender.Indentation--;

            var offsetParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + 1, context);
            builder.Parameters.AddParameter(offsetParam);
            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(context.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.IdentifierDelimiter.End).LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++.Indent().Write(context.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.IdentifierDelimiter.End)
                    .Write(".").Write(context.IdentifierDelimiter.Begin).Write("_index").Write(context.IdentifierDelimiter.End).Write(" BETWEEN ")
                    .Write(offsetParam.Parameter.ParameterName);

            if (expression.Limit.HasValue)
            {
                var limitParam = builder.Parameters.CreateInputParameter((expression.Offset ?? 0) + expression.Limit.Value, context);
                builder.Parameters.AddParameter(limitParam);
                builder.Appender
                    .Write(" AND ")
                    .Write(limitParam.Parameter.ParameterName)
                    .LineBreak();
            }
            builder.Appender
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write(context.IdentifierDelimiter.Begin).Write(outerTableAlias).Write(context.IdentifierDelimiter.End).Write(".").Write(context.IdentifierDelimiter.Begin).Write("_index").Write(context.IdentifierDelimiter.End).LineBreak();

        }

        private static void AppendSelectClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context, EntityExpressionAppendStyle entityAppendStyle, bool? isDistinct, int? top)
        {
            builder.Appender
                .Indent().Write("SELECT");

            if (isDistinct == true)
            {
                builder.Appender.Write(" DISTINCT");
            }

            if (top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(top.Value.ToString()).Write(")");
            }

            builder.Appender.LineBreak()
                .Indentation++;

            var select_list = expression.Select.Expressions.ToList();
            for (var i = 0; i < select_list.Count; i++)
            {
                var select = select_list[i];
                context.PushEntityAppendStyle(entityAppendStyle);
                try
                {
                    builder.Appender.Indent();
                    if (context.PrependCommaOnSelectClause && i > 0)
                        builder.Appender.Write(",");
                    try
                    {
                        context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);
                        builder.AppendElement(select.Expression, context);
                    }
                    finally
                    {
                        context.PopFieldAppendStyle();
                    }
                    if (!context.PrependCommaOnSelectClause && i < select_list.Count - 1)
                        builder.Appender.Write(",");
                    if (i < select_list.Count - 1)
                        builder.Appender.LineBreak();
                }
                finally
                {
                    context.PopEntityAppendStyle();
                }
            }

            builder.Appender.Indentation--;
        }
    }
}
