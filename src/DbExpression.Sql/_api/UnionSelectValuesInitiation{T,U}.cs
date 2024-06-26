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

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles   
    public interface UnionSelectValuesInitiation<TDatabase, TValue>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Construct an a sql SELECT query expression to UNION with the previous SELECT query expression.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/union-and-union-all">read the docs on UNION</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="UnionSelectValuesContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression.</returns>
        UnionSelectValuesContinuation<TDatabase, TValue> Union();

        /// <summary>
        /// Construct an a sql SELECT query expression to UNION ALL with the previous SELECT query expression.
        /// <para>
        /// <see href="https://dbexpression.com/docs/core-concepts/basics/union-and-union-all">read the docs on UNION</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="UnionSelectValuesContinuation{TDatabase}"/>, a fluent continuation for the construction of a sql SELECT query expression.</returns>
        UnionSelectValuesContinuation<TDatabase, TValue> UnionAll();
    }
}
