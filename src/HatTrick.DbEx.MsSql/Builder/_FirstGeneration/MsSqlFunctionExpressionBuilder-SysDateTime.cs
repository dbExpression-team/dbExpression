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

using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class FirstGenerationMsSqlFunctionExpressionBuilder
    {
        private static readonly SysDateTimeFunctionExpression sysDateTime = new();

        /// <summary>
        /// Construct an expression for the SYSDATETIME transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sysdatetime-transact-sql">Microsoft docs on SYSDATETIME</see></para>
        /// </summary>
        /// <returns><see cref="SysDateTimeFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public SysDateTimeFunctionExpression SysDateTime()
            => sysDateTime;
    }
}
