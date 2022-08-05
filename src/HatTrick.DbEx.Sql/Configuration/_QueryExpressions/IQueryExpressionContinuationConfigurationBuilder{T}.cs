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

using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IQueryExpressionContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a different query expression type for the <typeparamref name="TQuery"/> query expression.
        /// </summary>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, TQuery> ForQueryType<TQuery>()
            where TQuery : QueryExpression;

        /// <summary>
        /// Use a different query expression type for SELECT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{TQuery}"/>.</remarks>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, SelectQueryExpression> ForSelect();

        /// <summary>
        /// Use a different query expression type for INSERT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{TQuery}"/>.</remarks>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, InsertQueryExpression> ForInsert();

        /// <summary>
        /// Use a different query expression type for UPDATE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{TQuery}"/>.</remarks>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression> ForUpdate();

        /// <summary>
        /// Use a different query expression type for DELETE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{TQuery}"/>.</remarks>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression> ForDelete();
    }
}
