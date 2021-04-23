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
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblerFactoryConfigurationBuilder : ISqlStatementAssemblerFactoryConfigurationBuilder
    {
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;

        public SqlStatementAssemblerFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlStatementAssemblerFactory factory)
        {
            configuration.StatementAssemblerFactory = factory;
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlStatementAssemblerFactory>()
            where TSqlStatementAssemblerFactory : class, ISqlStatementAssemblerFactory, new()
        {
            configuration.StatementAssemblerFactory = new TSqlStatementAssemblerFactory();
            return caller;
        }

        public ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<QueryExpression, ISqlStatementAssembler> factory)
        {
            configuration.StatementAssemblerFactory = new DelegateSqlStatementAssemblerFactory(factory);
            return caller;
        }
    }
}
