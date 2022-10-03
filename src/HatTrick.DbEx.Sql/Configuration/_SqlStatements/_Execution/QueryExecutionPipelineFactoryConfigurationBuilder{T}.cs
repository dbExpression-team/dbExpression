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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase> :
        IQueryExecutionPipelineFactoryConfigurationBuilder<TDatabase>,
        IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public QueryExecutionPipelineFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(IQueryExpressionExecutionPipelineFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use<TQueryExecutionPipelineFactory>()
            where TQueryExecutionPipelineFactory : class, IQueryExpressionExecutionPipelineFactory
        {
            services.TryAddSingleton<IQueryExpressionExecutionPipelineFactory, TQueryExecutionPipelineFactory>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IQueryExpressionExecutionPipelineFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IQueryExpressionExecutionPipelineFactory>(sp => factory());

            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IQueryExpressionExecutionPipelineFactory> factory, Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureFactory is null)
                throw new ArgumentNullException(nameof(configureFactory));

            services.TryAddSingleton<IQueryExpressionExecutionPipelineFactory>(sp => factory());
            configureFactory(this);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IQueryExpressionExecutionPipelineFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IQueryExpressionExecutionPipelineFactory>(factory);

            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IQueryExpressionExecutionPipelineFactory> factory, Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureFactory is null)
                throw new ArgumentNullException(nameof(configureFactory));

            services.TryAddSingleton<IQueryExpressionExecutionPipelineFactory>(factory);
            configureFactory(this);
            return caller;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, TPipeline> ForPipelineType<TPipeline>()
            where TPipeline : class, IQueryExpressionExecutionPipeline
        {
            return new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase, TPipeline>(this, services);
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> ForPipelineTypes(Action<IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase>> configureFactory)
        {
            if (configureFactory is null)
                throw new ArgumentNullException(nameof(configureFactory));

            configureFactory(this);
            return caller;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, ISelectQueryExpressionExecutionPipeline> ForSelect()
        {
            return new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase, ISelectQueryExpressionExecutionPipeline>(this, services);
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IInsertQueryExpressionExecutionPipeline> ForInsert()
        {
            return new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase, IInsertQueryExpressionExecutionPipeline>(this, services);
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IUpdateQueryExpressionExecutionPipeline> ForUpdate()
        {
            return new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase, IUpdateQueryExpressionExecutionPipeline>(this, services);
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryContinuationConfigurationBuilder<TDatabase, IDeleteQueryExpressionExecutionPipeline> ForDelete()
        {
            return new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase, IDeleteQueryExpressionExecutionPipeline>(this, services);
        }
        #endregion
    }
}
