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
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityFactory : IEntityFactory
    {
        #region interface
        private readonly ConcurrentDictionary<Type, Func<IDbEntity>> typeFactories = new ConcurrentDictionary<Type, Func<IDbEntity>>();
        #endregion

        #region methods
        public virtual void RegisterFactory<TEntity>(Func<TEntity> factory)
            where TEntity : class, IDbEntity
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            typeFactories.AddOrUpdate(typeof(TEntity), factory, (t, f) => factory);
        }

        public virtual TEntity CreateEntity<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            if (typeFactories.TryGetValue(typeof(TEntity), out var factory))
                return factory.Invoke() as TEntity;

            return new TEntity();
        }
        #endregion
    }
}
