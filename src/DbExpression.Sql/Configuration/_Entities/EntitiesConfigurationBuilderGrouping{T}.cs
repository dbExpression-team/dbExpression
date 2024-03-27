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

using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbExpression.Sql.Configuration
{
    public class EntitiesConfigurationBuilderGrouping<TDatabase> : IEntitiesConfigurationBuilderGrouping<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        private IMapperFactoryConfigurationBuilder<TDatabase>? _mapper;
        private IEntityFactoryConfigurationBuilder<TDatabase>? _entity;
        #endregion

        #region interface
        /// <inheritdoc />
        public IEntityFactoryConfigurationBuilder<TDatabase> Creation => _entity ??= new EntityFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public IMapperFactoryConfigurationBuilder<TDatabase> Mapping => _mapper ??= new MapperFactoryConfigurationBuilder<TDatabase>(this, services);
        #endregion

        #region constructors
        public EntitiesConfigurationBuilderGrouping(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

    }
}
