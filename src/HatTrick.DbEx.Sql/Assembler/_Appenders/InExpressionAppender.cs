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
using System.Collections;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InExpressionAppender : ExpressionElementAppender<InExpression>
    {
        public override void AppendElement(InExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("IN (");
            AddParametersFromList(expression, builder, context);
            builder.Appender.Write(")");
        }

        private static void AddParametersFromList(InExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var hasElements = false;
            var enumerator = expression.Expression.GetEnumerator();
            var firstElement = true;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                    continue;

                if (!firstElement)
                {
                    builder.Appender.Write(',');
                }
                else
                {
                    firstElement = false;
                }
                
                var param = builder.Parameters.CreateInputParameter(
                       enumerator.Current is null || enumerator.Current is NullElement ? DBNull.Value : enumerator.Current,
                       (expression.Field as IExpressionTypeProvider).DeclaredType,
                       builder.FindMetadata(expression.Field) ?? throw new DbExpressionException($"Expected to find metadata for {expression.Field}, but metadata is actually null."),
                       context
                );
                builder.Parameters.AddParameter(param);
                builder.Appender.Write(param.Parameter.ParameterName);

                hasElements = true;
            }

            if (!hasElements)
                builder.Appender.Write("NULL");
        }
    }
}
