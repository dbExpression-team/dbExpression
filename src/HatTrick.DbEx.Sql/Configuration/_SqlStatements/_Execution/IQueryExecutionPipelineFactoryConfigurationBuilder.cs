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

﻿using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IQueryExecutionPipelineFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(IQueryExecutionPipelineFactory factory);

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>()
            where TExecutionPipelineFactory : class, IQueryExecutionPipelineFactory, new();

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TExecutionPipelineFactory"/>.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>(Action<TExecutionPipelineFactory> configureFactory)
            where TExecutionPipelineFactory : class, IQueryExecutionPipelineFactory, new();

        /// <summary>
        /// Use the default factory (highly recommended) for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory();
    }
}
