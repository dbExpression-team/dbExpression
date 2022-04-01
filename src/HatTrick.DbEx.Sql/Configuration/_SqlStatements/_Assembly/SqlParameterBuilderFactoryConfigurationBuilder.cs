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

﻿using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlParameterBuilderFactoryConfigurationBuilder : ISqlParameterBuilderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly SqlDatabaseRuntimeConfiguration configuration;

        public SqlParameterBuilderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, SqlDatabaseRuntimeConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlParameterBuilderFactory factory)
        {
            configuration.ParameterBuilderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>()
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new()
            => Use<TSqlParameterBuilderFactory>(_ => { });

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlParameterBuilderFactory>(Action<TSqlParameterBuilderFactory> configureFactory)
            where TSqlParameterBuilderFactory : class, ISqlParameterBuilderFactory, new()
        {
            if (configuration.ParameterBuilderFactory is not TSqlParameterBuilderFactory)
                configuration.ParameterBuilderFactory = new TSqlParameterBuilderFactory();
            configureFactory?.Invoke((configuration.ParameterBuilderFactory as TSqlParameterBuilderFactory)!);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<ISqlParameterBuilder> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory ?? throw new ArgumentNullException(nameof(factory)));
            return caller;
        }
    }
}
