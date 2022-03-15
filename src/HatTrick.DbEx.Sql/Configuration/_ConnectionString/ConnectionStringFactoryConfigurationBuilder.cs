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

﻿using HatTrick.DbEx.Sql.Connection;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ConnectionStringFactoryConfigurationBuilder : IConnectionStringFactoryConfigurationBuilder
    {
        #region internals
        private readonly SqlDatabaseRuntimeConfiguration configuration;
        #endregion

        #region constructors
        public ConnectionStringFactoryConfigurationBuilder(SqlDatabaseRuntimeConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void Use(string connectionString)
        {
            configuration.ConnectionStringFactory = new DelegateConnectionStringFactory(() => connectionString);
        }

        public void Use(Func<string> factory)
        {
            configuration.ConnectionStringFactory = new DelegateConnectionStringFactory(factory);
        }

        public void Use(IConnectionStringFactory factory)
        {
            configuration.ConnectionStringFactory = factory;
        }

        public void Use<TConnectionStringFactory>()
            where TConnectionStringFactory : class, IConnectionStringFactory, new()
        {
            if (configuration.ConnectionStringFactory is not TConnectionStringFactory)
                configuration.ConnectionStringFactory = new TConnectionStringFactory();
        }
        #endregion
    }
}
