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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExpressionTypeFactoryConfigurationBuilder<TDatabase, TQuery> : IQueryExpressionFactoryConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        private readonly IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;

        public QueryExpressionTypeFactoryConfigurationBuilder(
            IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> caller,
            IServiceCollection services
        )
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc />
        public IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : TQuery, new()
        {
            services.TryAddTransient<TQuery, T>();
            return caller;
        }

        /// <inheritdoc />
        public IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>(Func<T> factory)
            where T : TQuery
        {
            services.TryAddSingleton<TQuery>(sp => factory());
            return caller;
        }

        /// <inheritdoc />
        public IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>(Func<IServiceProvider, T> factory)
            where T : TQuery
        {
            services.TryAddSingleton<TQuery>(factory);
            return caller;
        }
    }
}
