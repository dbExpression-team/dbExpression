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

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DefaultMapperFactoryWithDiscovery : IMapperFactory
    {
        #region internals
        private readonly ILogger<DefaultMapperFactoryWithDiscovery> logger;
        private readonly Func<Type, IEntityMapper?> overrides;
        private readonly Func<IExpandoObjectMapper?> @override;
        private readonly Dictionary<Type, Func<Type, IEntityMapper?>> entityMappers = new();
        private bool isExpandoObjectMapperOverridden = true;
        private static readonly ExpandoObjectMapper expandoMapper = new();
        #endregion

        #region constructors
        public DefaultMapperFactoryWithDiscovery(
            ILogger<DefaultMapperFactoryWithDiscovery> logger, 
            Func<Type, IEntityMapper?> overrides, 
            Func<IExpandoObjectMapper?> @override
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
            this.@override = @override ?? throw new ArgumentNullException(nameof(@override));
        }
        #endregion

        #region methods
        public IEntityMapper<TEntity> CreateEntityMapper<TEntity>(Table<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            //try and resolve from local cache
            if (entityMappers.ContainsKey(typeof(TEntity)))
            {
                var map = entityMappers[entity.EntityType];
                return map(entity.EntityType) as IEntityMapper<TEntity> ?? throw new DbExpressionException($"A mapper of type {map.GetType()} was registered for entity type {typeof(TEntity)}.  The mapper does not provide mapping for {typeof(TEntity)}.");
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Mapper for {entity} not found in internal cache.", entity);

            //try and resolve from overrides
            IEntityMapper? overridenMapper = overrides(typeof(IEntityMapper<>).MakeGenericType(new[] { entity.EntityType }));
            if (overridenMapper is not null)
            {
                if (overridenMapper is IEntityMapper<TEntity> typedMapper)
                {
                    //register in local cache
                    entityMappers.Add(entity.EntityType, overrides);
                    return typedMapper;
                }
                throw new DbExpressionException($"A mapper of type {overridenMapper.GetType()} was registered for entity type {typeof(TEntity)}.  The mapper does not provide mapping for {typeof(TEntity)}.");
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Mapper for {entity} not found in provided overrides.", entity);


            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Mapper not found in internal cache or in provided overrides, creating a mapper for {entity} using type {mapperType}.", entity, typeof(EntityMapper<>));

            //build and register in local cache
            var entityMapper = new EntityMapper<TEntity>(entity.HydrateEntity);
            entityMappers.Add(typeof(TEntity), t => entityMapper);

            return entityMapper;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            if (!isExpandoObjectMapperOverridden)
                return expandoMapper;

            var mapper = @override();
            isExpandoObjectMapperOverridden = mapper is not null;

            if (logger.IsEnabled(LogLevel.Trace) && !isExpandoObjectMapperOverridden)
                logger.LogTrace("Mapper for dynamics not found in provided overrides, using default mapper type {mapperType}.", typeof(ExpandoObjectMapper));

            return mapper ?? expandoMapper;
        }
        #endregion
    }
}
