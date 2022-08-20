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
    public class QueryExpressionFactoryContinuationConfigurationBuilder<TDatabase, TQuery> : 
        IQueryExpressionContinuationConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        private readonly IQueryExpressionContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;

        public QueryExpressionFactoryContinuationConfigurationBuilder(IQueryExpressionContinuationConfigurationBuilder<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use<TUseQuery>() where TUseQuery : TQuery
        {
            services.TryAddTransient<TQuery, TUseQuery>();
            return caller;
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use(Func<TQuery> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddTransient<TQuery>(sp => factory());
            return caller;
        }

        /// <inheritdoc />
        public IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, TQuery> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddTransient<TQuery>(sp => factory(sp));
            return caller;
        }
    }
}
