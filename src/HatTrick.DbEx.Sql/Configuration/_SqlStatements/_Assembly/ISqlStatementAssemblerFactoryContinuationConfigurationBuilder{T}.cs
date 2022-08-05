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

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a different assembler for the <typeparamref name="TQuery"/> query expression.
        /// </summary>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery> ForQueryType<TQuery>()
            where TQuery : QueryExpression;

        /// <summary>
        /// Use a different assembler for SELECT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{SelectQueryExpression}"/>.</remarks>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, SelectQueryExpression> ForSelect();

        /// <summary>
        /// Use a different assembler for INSERT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{InsertQueryExpression}"/>.</remarks>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, InsertQueryExpression> ForInsert();

        /// <summary>
        /// Use a different assembler for UPDATE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{UpdateQueryExpression}"/>.</remarks>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression> ForUpdate();

        /// <summary>
        /// Use a different assembler for DELETE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{DeleteQueryExpression}"/>.</remarks>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression> ForDelete();
    }
}
