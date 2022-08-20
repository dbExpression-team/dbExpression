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

using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateAddFunctionExpressionAppender : ExpressionElementAppender<DateAddFunctionExpression>
    {
        #region methods
        public override void AppendElement(DateAddFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var datePart = (expression as IExpressionProvider<DatePartsExpression>).Expression;
            var parts = (expression as IExpressionListProvider<IExpressionElement>).Expressions;

            var value = datePart.Expression.ToString()?.ToLower();
            if (value is null)
                throw new DbExpressionException($"Expression is a null value, can't proceed with appending type {typeof(DatePartsExpression)} value to the appender.");

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
