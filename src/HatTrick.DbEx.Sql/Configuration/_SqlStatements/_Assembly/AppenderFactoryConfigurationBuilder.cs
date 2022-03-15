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
    public class AppenderFactoryConfigurationBuilder : IAppenderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly SqlDatabaseRuntimeConfiguration configuration;

        public AppenderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, SqlDatabaseRuntimeConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(IAppenderFactory factory)
        {
            configuration.AppenderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>()
            where TAppenderFactory : class, IAppenderFactory, new()
            => Use<TAppenderFactory>(_ => { });

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>(Action<TAppenderFactory> configureFactory)
            where TAppenderFactory : class, IAppenderFactory, new()
        {
            if (configuration.AppenderFactory is not TAppenderFactory)
                configuration.AppenderFactory = new TAppenderFactory();
            configureFactory?.Invoke((configuration.AppenderFactory as TAppenderFactory)!);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<IAppender> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory()
        {
            if (configuration.AppenderFactory is not AppenderFactory)
                configuration.AppenderFactory = new AppenderFactory();
            return caller;
        }
    }
}
