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
    public interface IQueryExecutionPipelineFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(IQueryExecutionPipelineFactory factory);

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use<TExecutionPipelineFactory>()
            where TExecutionPipelineFactory : class, IQueryExecutionPipelineFactory;

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate for creating an execution pipeline.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IQueryExecutionPipelineFactory> factory);

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate for creating an execution pipeline.</param>
        /// <param name="configureFactory">A delegate for specifying execution pipelines for specific query types.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IQueryExecutionPipelineFactory> factory, Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory);

        /// <summary>
        /// Use the service provider for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate for creating an execution pipeline.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IQueryExecutionPipelineFactory> factory);

        /// <summary>
        /// Use the service provider for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate for creating an execution pipeline.</param>
        /// <param name="configureFactory">A delegate for specifying execution pipelines for specific query types.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IQueryExecutionPipelineFactory> factory, Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory);

        /// <summary>
        /// Use the service provider for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate for creating an execution pipeline.</param>
        /// <param name="configureFactory">A delegate for specifying execution pipelines for specific query types.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> ForPipelineTypes(Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory);
    }
}
