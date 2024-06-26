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

using DbExpression.Sql.Pipeline;
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, TPipeline>
        where TDatabase : class, ISqlDatabaseRuntime
        where TPipeline : class, IQueryExpressionExecutionPipeline
    {
        /// <summary>
        /// Use this execution pipeline.
        /// </summary>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : class, TPipeline;

        /// <summary>
        /// Use a custom factory to provide an execution pipeline.
        /// </summary>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<TPipeline> factory);

        /// <summary>
        /// Use the service provider to provide an execution pipeline.
        /// </summary>
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, TPipeline> factory);
    }
}
