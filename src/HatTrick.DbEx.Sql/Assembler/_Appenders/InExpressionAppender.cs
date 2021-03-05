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
            AddParametersFromList(builder, context, expression.Expression);
            builder.Appender.Write(")");
        }

        private void AddParametersFromList(ISqlStatementBuilder builder, AssemblyContext context, IEnumerable expression)
        {
            var meta = context.Field is object ? builder.FindMetadata(context.Field) : null;
            var hasElements = false;
            var enumerator = expression.GetEnumerator();
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
                AddParameter(builder, context, meta, enumerator.Current);
                hasElements = true;
            }

            if (!hasElements)
                builder.Appender.Write("NULL");
        }

        private void AddParameter(ISqlStatementBuilder builder, AssemblyContext context, ISqlFieldMetadata meta, object expression)
        {
            if (context.Field is object)
            {
                builder.Appender.Write(
                   builder.Parameters.Add(
                       expression is null || expression is DBNull ? DBNull.Value : expression,
                       context, 
                       meta
                   )
                   .Parameter.ParameterName
               );
            }
            else
            {
                if (expression is null || expression is DBNull)
                {
                    return;
                }
                else
                {
                    builder.Appender.Write(builder.Parameters.Add(expression, expression.GetType(), context).ParameterName);
                }
            }
        }
    }
}
