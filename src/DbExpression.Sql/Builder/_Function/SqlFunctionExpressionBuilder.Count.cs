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
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the COUNT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/count">read the docs on COUNT</see></para>
        /// </summary>
        /// <returns><see cref="Int32CountFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32CountFunctionExpression Count()
            => new(new RawExpression('*'));

        /// <summary>
        /// Construct an expression for the COUNT transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/count">read the docs on COUNT</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, the value to use for calculating the count function result.</param>
        /// <returns><see cref="Int32CountFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32CountFunctionExpression Count(AnyElement element)
            => new(element);
    }
}
