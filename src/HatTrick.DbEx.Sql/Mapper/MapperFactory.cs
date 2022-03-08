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

﻿using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        #region internals
        private readonly ConcurrentDictionary<Type, Func<IMapper>> entityMappers = new();
        #endregion

        #region methods
        public void RegisterEntityMapper<TEntity>(Action<ISqlFieldReader, TEntity> converter)
            where TEntity : class, IDbEntity
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            entityMappers.AddOrUpdate(typeof(TEntity), () => new EntityMapper<TEntity>(converter), (t, f) => () => new EntityMapper<TEntity>(converter));
        }

        public IEntityMapper<TEntity> CreateEntityMapper<TEntity>(IEntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            if (entityMappers.TryGetValue(typeof(TEntity), out Func<IMapper>? provider))
            {
                var map = provider();
                if (map is null) throw new DbExpressionException($"Mapper for entity type {typeof(TEntity)} is not registered.");
                return map as IEntityMapper<TEntity> ?? throw new DbExpressionException($"A mapper of type {map.GetType()} was registered for entity type {typeof(TEntity)}.  The mapper does not provide mapping for {typeof(TEntity)}.");
            }

            var entityMap = new EntityMapper<TEntity>(entity.HydrateEntity);
            entityMappers.TryAdd(typeof(TEntity), () => entityMap);

            return entityMap;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => new ExpandoObjectMapper();
        #endregion
    }
}
