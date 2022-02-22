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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the CURRENT_TIMESTAMP transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/current-timestamp-transact-sql">Microsoft docs on CURRENT_TIMESTAMP</see></para>
        /// </summary>
        /// <returns><see cref="CurrentTimestampFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static CurrentTimestampFunctionExpression Current_Timestamp
            => new CurrentTimestampFunctionExpression();
    }
}
