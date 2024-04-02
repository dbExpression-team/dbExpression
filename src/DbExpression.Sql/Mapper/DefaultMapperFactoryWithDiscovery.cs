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

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DbExpression.Sql.Mapper
{
    public class DefaultMapperFactoryWithDiscovery : IMapperFactory
    {
        #region internals
        private readonly ILogger<DefaultMapperFactoryWithDiscovery> logger;
        private readonly Func<Type, IEntityMapper?> overrides;
        private readonly Func<IExpandoObjectMapper?> @override;
        private readonly ConcurrentDictionary<TypeDictionaryKey, Func<Type, IEntityMapper?>> entityMappers = new();
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
            var key = new TypeDictionaryKey(typeof(TEntity).TypeHandle.Value);
            if (entityMappers.TryGetValue(key, out Func<Type, IEntityMapper?>? map))
            {
                return map(entity.EntityType) as IEntityMapper<TEntity> ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IEntityMapper<TEntity>>();
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
                    entityMappers.TryAdd(new TypeDictionaryKey(entity.EntityType.TypeHandle.Value), overrides);
                    return typedMapper;
                }
                DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IEntityMapper<TEntity>>();
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Mapper for {entity} not found in provided overrides.", entity);


            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Mapper not found in internal cache or in provided overrides, creating a mapper for {entity} using type {mapperType}.", entity, typeof(EntityMapper<>));

            //build and register in local cache
            var entityMapper = new EntityMapper<TEntity>(entity.HydrateEntity);
            entityMappers.TryAdd(key, t => entityMapper);

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

        #region classes
        private readonly struct TypeDictionaryKey : IEquatable<TypeDictionaryKey>
        {
            #region interface
            public readonly IntPtr Ptr;
            #endregion

            #region constructors
            public TypeDictionaryKey(IntPtr key) => Ptr = key;
            #endregion

            #region methods
            public bool Equals(TypeDictionaryKey other)
                => Ptr == other.Ptr;

            public override int GetHashCode() => Ptr.GetHashCode();

            public override bool Equals(object? obj)
                => obj is TypeDictionaryKey other && Equals(other);
            #endregion
        }
        #endregion
    }
}
