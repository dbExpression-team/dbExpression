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
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinExpressionAppender : ExpressionElementAppender<JoinExpression>
    {        
        public override void AppendElement(JoinExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent()
                .Write(expression.JoinType.ToString())
                .Write(" JOIN ");

            if (expression.JoinToo is QueryExpression joinExpression)
            {
                builder.Appender.Write("(").LineBreak()
                    .Indentation++;

                //append the subquery
                builder.AppendElement(joinExpression, context);

                //append the subquery alias
                builder.Appender.Indentation--.LineBreak().Indent().Write(") AS ")
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write(builder.ResolveTableAlias((expression as IExpressionAliasProvider).Alias!)!)
                    .Write(context.IdentifierDelimiter.End)
                    .Write(" ON ");

                builder.AppendElement(expression.JoinOnExpression!, context);

                return;
            }

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.JoinToo, context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            if (expression.JoinType == JoinOperationExpressionOperator.CROSS)
                return;

            builder.Appender.Write(" ON ");
            builder.AppendElement(expression.JoinOnExpression!, context);
        }
    }
}
