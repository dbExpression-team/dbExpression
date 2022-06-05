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

using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DelegateMapperFactory : IMapperFactory
    {
        #region internals
        private readonly Func<Type,IEntityMapper> entityMapperFactory;
        private readonly Func<IExpandoObjectMapper> expandoObjectMapperFactory;
        #endregion

        #region constructors
        public DelegateMapperFactory(Func<Type, IEntityMapper> entityMapperFactory, Func<IExpandoObjectMapper> expandoObjectMapperFactory)
        {
            this.entityMapperFactory = entityMapperFactory ?? throw new ArgumentNullException(nameof(entityMapperFactory));
            this.expandoObjectMapperFactory = expandoObjectMapperFactory ?? throw new ArgumentNullException(nameof(expandoObjectMapperFactory));
        }
        #endregion

        #region methods
        public IEntityMapper<TEntity> CreateEntityMapper<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            var mapper = entityMapperFactory(typeof(TEntity)) ?? throw new DbExpressionConfigurationException($"The factory returned a null mapper for entity type {typeof(TEntity)}.");
            if (mapper is IEntityMapper<TEntity> entityMapper)
                return entityMapper;
            throw new DbExpressionConfigurationException($"The factory is not an {typeof(IEntityMapper<TEntity>).Name}, cannot use the factory to create a mapper for entity type {typeof(TEntity)}.");
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => expandoObjectMapperFactory() ?? throw new DbExpressionConfigurationException($"The factory returned a null mapper for an {typeof(IExpandoObjectMapper).Name}");
        #endregion
    }
}
