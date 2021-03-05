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
    public class ExpressionElementAppenderFactoryConfigurationBuilder : IExpressionElementAppenderFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public ExpressionElementAppenderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(IExpressionElementAppenderFactory factory)
        {
            configuration.ExpressionElementAppenderFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>()
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new()
            => Use<TExpressionElementAppenderFactory>(null);

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TExpressionElementAppenderFactory>(Action<TExpressionElementAppenderFactory> configureFactory)
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory, new()
        {
            if (!(configuration.ExpressionElementAppenderFactory is TExpressionElementAppenderFactory))
                configuration.ExpressionElementAppenderFactory = new TExpressionElementAppenderFactory();
            configureFactory?.Invoke(configuration.ExpressionElementAppenderFactory as TExpressionElementAppenderFactory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<Type, IExpressionElementAppender> factory)
        {
            configuration.ExpressionElementAppenderFactory = new DelegateExpressionElementAppenderFactory(factory);
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory()
        {
            configuration.ExpressionElementAppenderFactory = new ExpressionElementAppenderFactory();
            return caller;
        }
    }
}
