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

﻿using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityExpressionAppender : ExpressionElementAppender<EntityExpression>
    {
        public override void AppendElement(EntityExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.Alias)
            {
                var alias = (expression as IExpressionAliasProvider).Alias;
                if (!string.IsNullOrWhiteSpace(alias))
                {
                    builder.Appender
                        .Write(context.IdentifierDelimiter.Begin)
                        .Write(alias!)
                        .Write(context.IdentifierDelimiter.End);
                    return;
                }
            }

            if (context.IncludeSchemaName)
            {
                builder.AppendElement((expression as Table).Schema, context);
                builder.Appender.Write(".");
            }

            builder.Appender
                .Write(context.IdentifierDelimiter.Begin)
                .Write((builder.FindMetadata(expression) ?? throw new DbExpressionException($"Expected to find metadata for {expression}, but metadata is actually null.")).Name)
                .Write(context.IdentifierDelimiter.End);

            AppendAlias(expression, builder, context);
        }

        protected static void AppendAlias(IExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (string.IsNullOrWhiteSpace(aliasable.Alias) || context.EntityExpressionAppendStyle != EntityExpressionAppendStyle.Declaration)
                return;

            builder.Appender.Write(" AS ")
                .Write(context.IdentifierDelimiter.Begin)
                .Write(aliasable.Alias!)
                .Write(context.IdentifierDelimiter.End);
        }
    }
}
