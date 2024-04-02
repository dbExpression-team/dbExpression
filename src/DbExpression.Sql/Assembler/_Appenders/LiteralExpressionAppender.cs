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

using DbExpression.Sql.Expression;
using System;

namespace DbExpression.Sql.Assembler
{
    public class LiteralExpressionAppender : ExpressionElementAppender<LiteralExpression>
    {
        private static readonly NullExpression _null = new();

        public override void AppendElement(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var (convertedType, convertedValue) = builder.ConvertValue(expression.Expression, expression.Field);
            if (convertedValue is null)
            {
                builder.AppendElement(_null, context);
                return;
            }

            ParameterizedExpression param;
            if (expression.Field is not null)
            {
                param = builder.Parameters.CreateInputParameter(
                        convertedValue,
                        convertedType,
                        builder.GetPlatformMetadata(expression.Field),
                        context
                    );
            }
            else
            {
                param = builder.Parameters.CreateInputParameter(
                        convertedValue,
                        convertedType,
                        context
                    );
            }
            builder.Parameters.AddParameter(param);
            builder.Appender.Write(param.Parameter.ParameterName);
        }
    }
}
