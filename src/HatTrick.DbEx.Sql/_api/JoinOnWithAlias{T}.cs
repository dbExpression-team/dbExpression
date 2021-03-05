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

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JoinOnWithAlias<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Specify an alias of a JOIN clause.
        /// <para>
        /// Use the <paramref name="alias"/> value from this operation as the 'tableName' parameter when creating an <see cref="AliasExpression"/> 
        /// (for the joined sql SELECT query expression) for use with outer expressions:
        /// <code>dbex.alias({tableName}, {fieldName})</code>
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="alias">The alias to apply to the JOIN clause.</param>
        /// <returns><typeparamref name="TCaller"/>, a fluent continuation for the construction of a sql query expression.</returns>
        JoinOn<TCaller> As(string alias);
    }
}
