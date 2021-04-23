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
    public class LiteralExpressionAppender : ExpressionElementAppender<LiteralExpression>
    {
        public override void AppendElement(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.Field is object)
            {
                builder.Appender.Write(
                   builder.Parameters.Add(
                       expression.Expression,
                       context,
                       builder.FindMetadata(context.Field)
                   )
                   .Parameter.ParameterName
               );
            }
            else
            {
                if (expression.Expression is null || expression.Expression is DBNull)
                {
                    builder.Appender.Write("NULL");
                }
                else
                {
                    builder.Appender.Write(
                        builder.Parameters.Add(
                            expression.Expression, 
                            expression.Expression.GetType(),
                            context
                        )
                        .ParameterName
                    );
                }
            }
        }
    }
}
