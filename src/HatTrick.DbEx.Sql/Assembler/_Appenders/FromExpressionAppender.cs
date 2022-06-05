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

using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FromExpressionAppender : ExpressionElementAppender<FromExpression>
    {
        public override void AppendElement(FromExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Expression is QueryExpression)
                builder.Appender.Write('(').LineBreak().Indentation++;
            else
                builder.Appender.Indentation++.Indent();


            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.Expression, context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }


            if (expression.Expression is QueryExpression)
                builder.Appender.LineBreak().Indentation--.Write(')');
            else
                builder.Appender.Indentation--;

            AppendAlias(expression, builder, context);
        }

        protected static void AppendAlias(IExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (string.IsNullOrWhiteSpace(aliasable.Alias))
                return;

            builder.Appender.Write(" AS ")
                .Write(context.IdentifierDelimiter.Begin)
                .Write(aliasable.Alias!)
                .Write(context.IdentifierDelimiter.End);
        }
    }
}
