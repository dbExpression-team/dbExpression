﻿#region license
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

using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Builder
{
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        private static readonly SysDateTimeOffsetFunctionExpression sysDateTimeOffset = new();

        /// <summary>
        /// Construct an expression for the SYSDATETIMEOFFSET transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/sysdatetimeoffset">read the docs on SYSDATETIMEOFFSET</see></para>
        /// </summary>
        /// <returns><see cref="SysDateTimeOffsetFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public SysDateTimeOffsetFunctionExpression SysDateTimeOffset()
            => sysDateTimeOffset;
    }
}
