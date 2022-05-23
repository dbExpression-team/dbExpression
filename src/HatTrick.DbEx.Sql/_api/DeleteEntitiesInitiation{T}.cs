﻿#region license
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

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface DeleteEntitiesInitiation<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Start constructing a sql DELETE query expression to remove records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql">Microsoft docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="DeleteEntities{TDatabase}"/>, a fluent builder for constructing a sql DELETE statement.</returns>
        DeleteEntities<TDatabase> Delete();
    }
}
