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
    public class FieldExpressionAppender : ExpressionElementAppender<FieldExpression>
    {
        public override void AppendElement(FieldExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.EntityExpressionAppendStyle != EntityExpressionAppendStyle.None)
            {
                builder.AppendElement((expression as Field).Table, context);
                builder.Appender.Write(".");
            }

            if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.Alias
                && expression is IExpressionAliasProvider isAlias 
                && !string.IsNullOrWhiteSpace(isAlias.Alias))
            {
                return;
            }

            builder.Appender
                .Write(context.IdentifierDelimiter.Begin)
                .Write(builder.GetPlatformName(expression))
                .Write(context.IdentifierDelimiter.End);
        }
    }
}
