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

﻿using DbExpression.Sql.Attribute;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Assembler
{
    public class FilterExpressionSetAppender : ExpressionElementAppender<FilterExpressionSet>
    {
        #region internals
        private static readonly Dictionary<ConditionalExpressionOperator, string> conditionalOperatorMap;
        #endregion

        #region constructors
        static FilterExpressionSetAppender()
        {
            conditionalOperatorMap = typeof(ConditionalExpressionOperator).GetValuesAndConditionalOperators().ToDictionary(k => k.Key, v => v.Value!);
        }
        #endregion

        #region methods
        public override void AppendElement(FilterExpressionSet exp, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var expression = (exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>).Expression;
            if (expression is null || !expression.Args.Any())
                return;

            //if the expression set is negated, render "NOT"
            var argCount = expression.Args.Count();
            if (expression.Negate)
                AppendNegateStart(builder.Appender);

            for (var i = 0; i < argCount; i++)
            {
                var current = expression.Args.ElementAt(i);
                var elementSet = expression.Args.ElementAt(i) as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>;

                if (argCount > 1 && elementSet is not null)
                    AppendParensStart(builder.Appender);
                  
                builder.AppendElement(current, context);

                if (argCount > 1 && elementSet is not null)
                    AppendParensEnd(builder.Appender);

                if (i < argCount - 1) 
                    AppendConditionalOperator(builder.Appender, expression.ConditionalOperator);
            }

            if (expression.Negate)
                AppendNegateEnd(builder.Appender);
        }

        private static void AppendNegateStart(IAppender appender)
            => appender
                    .Write("NOT")
                    .LineBreak()
                    .Indent()
                    .Write('(')
                    .LineBreak()
                    .Indentation++
                    .Indent();

        private static void AppendNegateEnd(IAppender appender)
            => appender
                    .LineBreak()
                    .Indentation--
                    .Indent()
                    .Write(')');

        private static void AppendParensStart(IAppender appender)
            => appender
                    .Write('(')
                    .LineBreak()
                    .Indentation++
                    .Indent();

        private static void AppendParensEnd(IAppender appender)
            => appender
                    .LineBreak()
                    .Indentation--
                    .Indent()
                    .Write(')');

        private static void AppendConditionalOperator(IAppender appender, ConditionalExpressionOperator condition)
            => appender
                    .LineBreak()
                    .Indent()
                    .Write(conditionalOperatorMap[condition])
                    .LineBreak()
                    .Indent();
        #endregion
    }
}
