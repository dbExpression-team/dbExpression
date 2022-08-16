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

using HatTrick.DbEx.Sql.Pipeline;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use the execution pipeline type <typeparamref name="TQuery"/> to assemble and execute queries.
        /// </summary>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, TPipeline> ForPipelineType<TPipeline>()
            where TPipeline : class, IQueryExecutionPipeline;

        /// <summary>
        /// Use a different query expression type for SELECT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForQueryType{TQuery}"/>.</remarks>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, ISelectQueryExecutionPipeline> ForSelect();

        /// <summary>
        /// Use the execution pipeline type to assemble and execute INSERT queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForPipelineType{TPipeline}"/>.</remarks>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IInsertQueryExecutionPipeline> ForInsert();

        /// <summary>
        /// Use the execution pipeline type to assemble and execute UPDATE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForPipelineType{TPipeline}"/>.</remarks>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IUpdateQueryExecutionPipeline> ForUpdate();

        /// <summary>
        /// Use the execution pipeline type to assemble and execute DELETE queries.
        /// </summary>
        /// <remarks>This method is shorthand for <see cref="ForPipelineType{TPipeline}"/>.</remarks>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IDeleteQueryExecutionPipeline> ForDelete();
    }
}
