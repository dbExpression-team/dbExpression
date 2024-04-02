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

﻿using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace DbExpression.Sql.Configuration
{
    public class QueryExpressionFactoryConfigurationBuilder<TDatabase> : 
        IQueryExpressionFactoryConfigurationBuilder<TDatabase>,
        IQueryExpressionContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public QueryExpressionFactoryConfigurationBuilder(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public void Use(IQueryExpressionFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
        }

        /// <inheritdoc />
        public void Use<TQueryExpressionFactory>()
            where TQueryExpressionFactory : class, IQueryExpressionFactory
        {
            services.TryAddSingleton<IQueryExpressionFactory, TQueryExpressionFactory>();
        }

        /// <inheritdoc />
        public void Use(Func<IQueryExpressionFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IQueryExpressionFactory>(sp => factory());
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IQueryExpressionFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IQueryExpressionFactory>(factory);
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IQueryExpressionFactory> factory, Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureFactory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureFactory is null)
                throw new ArgumentNullException(nameof(configureFactory));

            services.TryAddSingleton<IQueryExpressionFactory>(factory);

            configureFactory.Invoke(this);
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, QueryExpression> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IQueryExpressionFactory>(sp => new DelegateQueryExpressionFactory(t => factory(sp, t)));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, QueryExpression> factory, Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureFactory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureFactory is null)
                throw new ArgumentNullException(nameof(configureFactory));

            services.TryAddSingleton<IQueryExpressionFactory>(sp => new DelegateQueryExpressionFactory(t => factory(sp,t)));

            configureFactory.Invoke(this);
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase, TQuery> ForQueryType<TQuery>() where TQuery : QueryExpression
        {
            return new QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, TQuery>(this, services);
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase, SelectQueryExpression> ForSelect()
        {
            return new QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, SelectQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase, InsertQueryExpression> ForInsert()
        {
            return new QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, InsertQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression> ForUpdate()
        {
            return new QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression> ForDelete()
        {
            return new QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public void ForQueryTypes(Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureQueryTypes)
        {
            if (configureQueryTypes is null)
                throw new ArgumentNullException(nameof(configureQueryTypes));

            configureQueryTypes.Invoke(new QueryExpressionFactoryConfigurationBuilder<TDatabase>(services));
        }
        #endregion
    }
}
