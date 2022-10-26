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
            var enumerator = expression.Values.GetEnumerator();
            var firstElement = true;
            Type? valueType = (expression.Expression as IExpressionTypeProvider)?.DeclaredType;
            FieldExpression? field = expression.Expression.AsFieldExpression();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                    continue;

                if (valueType is null)
                    valueType = enumerator.Current.GetType();

                if (!firstElement)
                {
                    builder.Appender.Write(',');
                }
                else
                {
                    firstElement = false;
                }

                ParameterizedExpression? param = null;
                if (field is not null)
                {
                    param = builder.Parameters.CreateInputParameter(
                           enumerator.Current is NullElement ? DBNull.Value : enumerator.Current,
                           valueType,
                           builder.GetPlatformMetadata(field) ?? throw new DbExpressionException($"Expected to find metadata for {field}, but metadata is actually null."),
                           context
                    );
                }
                else
                {
                    param = builder.Parameters.CreateInputParameter(
                           enumerator.Current is NullElement ? DBNull.Value : enumerator.Current,
                           valueType,
                           context
                    );
                }

                builder.Parameters.AddParameter(param);
                builder.Appender.Write(param.Parameter.ParameterName);

                hasElements = true;
            }

            if (!hasElements)
                builder.Appender.Write("NULL");
        }
    }
}
