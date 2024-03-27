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

namespace DbExpression.Sql.Configuration
{
    public interface IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom query expression type for queries using <typeparamref name="TQuery"/>. 
        /// </summary>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase, TQuery> ForQueryType<TQuery>()
            where TQuery : QueryExpression;

        /// <summary>
        /// Use a custom query expression type for SELECT queries (<see cref="SelectQueryExpression"/>). 
        /// </summary>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase, SelectQueryExpression> ForSelect();

        /// <summary>
        /// Use a custom query expression type for INSERT queries (<see cref="InsertQueryExpression"/>). 
        /// </summary>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase, InsertQueryExpression> ForInsert();

        /// <summary>
        /// Use a custom query expression type for UPDATE queries (<see cref="UpdateQueryExpression"/>). 
        /// </summary>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase, UpdateQueryExpression> ForUpdate();

        /// <summary>
        /// Use a custom query expression type for DELETE queries (<see cref="DeleteQueryExpression"/>). 
        /// </summary>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase, DeleteQueryExpression> ForDelete();
    }
}
