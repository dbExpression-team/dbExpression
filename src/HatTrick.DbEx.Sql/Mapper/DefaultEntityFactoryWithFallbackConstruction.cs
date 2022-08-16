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
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DefaultEntityFactoryWithFallbackConstruction : IEntityFactory
    {
        #region internals
        private readonly ILogger<DefaultEntityFactoryWithFallbackConstruction> logger;
        private readonly Func<Type, IDbEntity?> factory;
        private readonly ConcurrentDictionary<Type, Func<Type, IDbEntity?>> map = new();
        #endregion

        #region constructors
        public DefaultEntityFactoryWithFallbackConstruction(ILogger<DefaultEntityFactoryWithFallbackConstruction> logger, Func<Type, IDbEntity?> factory)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public TEntity CreateEntity<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            if (map.ContainsKey(typeof(TEntity)))
                return (map[typeof(TEntity)](typeof(TEntity)) as TEntity)!;

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Entity factory for {entity} not found in internal cache.", typeof(TEntity));

            var entity = factory(typeof(TEntity));
            if (entity is not null)
                return (entity as TEntity)!;

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Entity factory for {entity} not found in provided factory.", typeof(TEntity));

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Entity factory not found in internal cache or in provided factory, creating a factory for {entity} using public parameterless constructor.", typeof(TEntity));

            map.TryAdd(typeof(TEntity), t => new TEntity());
            return CreateEntity<TEntity>();
        }
        #endregion
    }
}
