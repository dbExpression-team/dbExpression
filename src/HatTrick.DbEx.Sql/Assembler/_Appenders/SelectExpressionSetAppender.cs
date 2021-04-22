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
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionSetAppender : ExpressionElementAppender<SelectExpressionSet>
    {        
        public override void AppendElement(SelectExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            var selects = expression.Expressions.ToList();
            for (var i = 0; i < selects.Count; i++)
            {
                builder.Appender.Indent();
                if (context.Configuration.PrependCommaOnSelectClause && i > 0)
                {
                    builder.Appender.Write(",");
                }

                builder.AppendElement(selects[i], context);

                if (!context.Configuration.PrependCommaOnSelectClause && i < selects.Count - 1)
                {
                    builder.Appender.Write(",");
                }

                builder.Appender.LineBreak();
            }
        }
    }
}
