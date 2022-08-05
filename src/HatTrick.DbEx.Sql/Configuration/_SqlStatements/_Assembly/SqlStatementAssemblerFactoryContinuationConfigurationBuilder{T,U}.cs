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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery> : 
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        private readonly ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;

        public SqlStatementAssemblerFactoryContinuationConfigurationBuilder(
            ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> caller, 
            IServiceCollection services
        )
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(ISqlStatementAssembler<TDatabase, TQuery> assembler)
        {
            services.TryAddSingleton<ISqlStatementAssembler<TDatabase, TQuery>>(assembler);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use<TAssembler>()
            where TAssembler : class, ISqlStatementAssembler<TDatabase, TQuery>
        {
            services.TryAddSingleton<ISqlStatementAssembler<TDatabase, TQuery>, TAssembler>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<ISqlStatementAssembler<TDatabase, TQuery>> factory)
        {
            services.TryAddSingleton<ISqlStatementAssembler<TDatabase, TQuery>>(sp => factory());
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssembler<TDatabase, TQuery>> factory)
        {
            services.TryAddSingleton<ISqlStatementAssembler<TDatabase, TQuery>>(factory);
            return caller;
        }
    }
}
