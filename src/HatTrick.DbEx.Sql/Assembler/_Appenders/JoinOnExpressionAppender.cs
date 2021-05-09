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

﻿using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinOnExpressionAppender : ExpressionElementAppender<JoinOnExpression>
    {
        #region internals
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));
        #endregion

        #region methods
        public override void AppendElement(JoinOnExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            try
            {
                if (expression.Negate)
                {
                    builder.Appender.Write("NOT (");
                }
                builder.AppendElement(expression.LeftArg, context);

                builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
                builder.AppendElement(expression.RightArg, context);
                
                if (expression.Negate)
                {
                    builder.Appender.Write(')');
                }
            }
            finally
            {
                context.PopAppendStyles();
            }
        }
        #endregion
    }
}
