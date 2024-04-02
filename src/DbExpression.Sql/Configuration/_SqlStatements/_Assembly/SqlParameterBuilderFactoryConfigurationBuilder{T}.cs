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

﻿using DbExpression.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace DbExpression.Sql.Configuration
{
    public class SqlParameterBuilderFactoryConfigurationBuilder<TDatabase> : ISqlParameterBuilderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller;
        private readonly IServiceCollection services;

        public SqlParameterBuilderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TSqlParameterBuilder>()
            where TSqlParameterBuilder : class, ISqlParameterBuilder
        {
            services.TryAddTransient<ISqlParameterBuilder, TSqlParameterBuilder>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<ISqlParameterBuilder> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddTransient<ISqlParameterBuilder>(sp => factory());
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlParameterBuilder> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddTransient<ISqlParameterBuilder>(sp => factory(sp));
            return caller;
        }
    }
}
