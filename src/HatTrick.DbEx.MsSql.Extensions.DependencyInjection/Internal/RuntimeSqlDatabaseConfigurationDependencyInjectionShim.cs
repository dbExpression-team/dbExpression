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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Expression.DependencyInjection.Internal
{
    internal class RuntimeSqlDatabaseConfigurationDependencyInjectionShim
    {
        #region interface
        public IRuntimeSqlDatabase Database { get; private set; }
        public Func<RuntimeSqlDatabaseConfiguration> ConfigurationFactory { get; private set; }
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationDependencyInjectionShim(IRuntimeSqlDatabase database, Func<RuntimeSqlDatabaseConfiguration> configurationFactory)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.ConfigurationFactory = configurationFactory ?? throw new ArgumentNullException(nameof(configurationFactory));
        }
        #endregion
    }
}
