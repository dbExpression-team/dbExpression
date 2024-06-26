﻿#region license
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
using System.Data;

namespace DbExpression.Sql.Assembler
{
    public class ParameterExpressionAppender : ExpressionElementAppender<ParameterExpression>
    {
        public override void AppendElement(ParameterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            ParameterizedExpression param;
            var meta = builder.GetPlatformMetadata(expression);

            switch (expression.Direction)
            {
                case ParameterDirection.Input:
                    param = builder.Parameters.CreateInputParameter(
                            expression.Value,
                            (expression as IExpressionTypeProvider).DeclaredType,
                            meta,
                            context
                        );
                    break;
                case ParameterDirection.InputOutput:
                    param = builder.Parameters.CreateInputOutputParameter(
                            expression.Value,
                            (expression as IExpressionTypeProvider).DeclaredType,
                            meta,
                            context
                        );
                    break;
                case ParameterDirection.Output:
                    param = builder.Parameters.CreateOutputParameter(
                        (expression as IExpressionTypeProvider).DeclaredType,
                        meta,
                        context
                    );
                    break;
                default:
                    throw new NotImplementedException($"Parameter direction {expression.Direction} has not been implemented.");
            }
            builder.Parameters.AddParameter(param);
        }
    }
}
