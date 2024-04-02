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

using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using System.Linq;

namespace DbExpression.MsSql.Assembler
{
    public class DateAddFunctionExpressionAppender : ExpressionElementAppender<DateAddFunctionExpression>
    {
        #region methods
        public override void AppendElement(DateAddFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var datePart = (expression as IExpressionProvider<DatePartsExpression>).Expression!;
            var parts = (expression as IExpressionListProvider<IExpressionElement>).Expressions;

            var value = datePart.Expression.ToString()?.ToLower();
            if (value is null)
                DbExpressionQueryException.ThrowNullValueUnexpected(expression);

            builder.Appender
                .Write("DATEADD(")
                .Write(value)
                .Write(", ");

            builder.AppendElement(parts.First(), context);
            builder.Appender.Write(", ");
            builder.AppendElement(parts.Last(), context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
