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
    public class AliasExpressionAppender : ExpressionElementAppender<AliasExpression>
    {
        public override void AppendElement(AliasExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var alias = (expression as IExpressionProvider<AliasExpression.AliasExpressionElements>).Expression;
            if (!string.IsNullOrWhiteSpace(alias.TableAlias))
            {
                builder.Appender
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write(alias.TableAlias!)
                    .Write(context.IdentifierDelimiter.End);
            }

            if (!string.IsNullOrWhiteSpace(alias.TableAlias) && !string.IsNullOrWhiteSpace(alias.FieldAlias))
            {
                builder.Appender.Write(".");
            }

            if (!string.IsNullOrWhiteSpace(alias.FieldAlias))
            {
                builder.Appender
                  .Write(context.IdentifierDelimiter.Begin)
                  .Write(alias.FieldAlias)
                  .Write(context.IdentifierDelimiter.End);
            }
        }
    }
}
