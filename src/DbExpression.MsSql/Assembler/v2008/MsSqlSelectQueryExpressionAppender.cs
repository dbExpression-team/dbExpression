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

using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;

namespace DbExpression.MsSql.Assembler.v2008
{
    public class MsSqlSelectQueryExpressionAppender : DbExpression.MsSql.Assembler.MsSqlSelectQueryExpressionAppender
    {
        public override void AppendElement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.Offset.HasValue && !expression.Limit.HasValue)
            {
                //no paging, so no special handling required
                base.AppendElement(expression, builder, context);
            }
            else if (expression.Distinct == true)
            {
                //distinct, return modified CTE for page
                AssembleMsSqlDistinctCTESelectStatement(expression, builder, context);
            }
            else
            {
                //no distinct, return standard CTE for page
                AssembleMsSqlCTESelectStatement(expression, builder, context);
            }
        }
    }
}
