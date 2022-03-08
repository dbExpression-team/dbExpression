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
    public class EntitiesConfigurationBuilderGrouping : IEntitiesConfigurationBuilderGrouping
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IMapperFactoryConfigurationBuilder? _mapper;
        private IEntityFactoryConfigurationBuilder? _entity;
        #endregion

        #region interface
        public IEntityFactoryConfigurationBuilder Creation => _entity ??= new EntityFactoryConfigurationBuilder(this, configuration);
        public IMapperFactoryConfigurationBuilder Mapping => _mapper ??= new MapperFactoryConfigurationBuilder(this, configuration);
        #endregion

        #region constructors
        public EntitiesConfigurationBuilderGrouping(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

    }
}
