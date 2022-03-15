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

﻿using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlDatabaseMetadataProviderConfigurationBuilder : ISqlDatabaseMetadataProviderConfigurationBuilder
    {
        #region internals
        private readonly SqlDatabaseRuntimeConfiguration configuration;
        #endregion

        #region constructors
        public SqlDatabaseMetadataProviderConfigurationBuilder(SqlDatabaseRuntimeConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void Use(ISqlDatabaseMetadataProvider provider)
            => configuration.MetadataProvider = provider ?? throw new ArgumentNullException(nameof(provider));

        public void Use<TSqlDatabaseMetadataProvider>()
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new()
            => Use<TSqlDatabaseMetadataProvider>(_ => { });

        public void Use<TSqlDatabaseMetadataProvider>(Action<TSqlDatabaseMetadataProvider> configureProvider)
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new()
        {
            if (configuration.MetadataProvider is not TSqlDatabaseMetadataProvider)
                configuration.MetadataProvider = new TSqlDatabaseMetadataProvider();
            configureProvider?.Invoke((configuration.MetadataProvider as TSqlDatabaseMetadataProvider)!);
        }
        #endregion
    }
}
