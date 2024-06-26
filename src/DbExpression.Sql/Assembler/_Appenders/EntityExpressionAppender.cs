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

﻿using DbExpression.Sql.Expression;

namespace DbExpression.Sql.Assembler
{
    public class EntityExpressionAppender : ExpressionElementAppender<EntityExpression>
    {
        public override void AppendElement(EntityExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.None)
                return;

            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.Name)
            {
                builder.AppendElement((expression as Table).Schema, context);
                builder.Appender.Write('.')
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write(builder.GetPlatformName(expression))
                    .Write(context.IdentifierDelimiter.End);
                return;
            }

            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.Declaration)
            {
                builder.AppendElement((expression as Table).Schema, context);
                builder.Appender.Write('.')
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write(builder.GetPlatformName(expression))
                    .Write(context.IdentifierDelimiter.End)
                    .Write(" AS ");
            }

            //EntityExpressionAppendStyle.Declaration & EntityExpressionAppendStyle.Alias
            builder.Appender
                .Write(context.IdentifierDelimiter.Begin)
                .Write(builder.ResolveTableAlias(expression)!)
                .Write(context.IdentifierDelimiter.End);
        }
    }
}
