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
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ParameterExpressionAppender : ExpressionElementAppender<ParameterExpression>
    {
        public override void AppendElement(ParameterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            ParameterizedExpression param;
            switch (expression.Direction)
            {
                case ParameterDirection.Input:
                    param = builder.Parameters.CreateInputParameter(
                            expression.Value,
                            expression.DeclaredType,
                            context
                        );
                    break;
                case ParameterDirection.InputOutput:
                    param = builder.Parameters.CreateInputOutputParameter(
                            expression.Value,
                            expression.DeclaredType,
                            context
                        );
                    break;
                case ParameterDirection.Output:
                    param = builder.Parameters.CreateOutputParameter(
                        expression.DeclaredType,
                        context
                    );
                    break;
                default:
                    throw new DbExpressionException($"Parameter direction {expression.Direction} has not been implemented.", new NotImplementedException($"Parameter direction {expression.Direction} has not been implemented."));
            }
            builder.Parameters.AddParameter(param);
            param.Parameter.ParameterName = expression.Name;
        }
    }
}
