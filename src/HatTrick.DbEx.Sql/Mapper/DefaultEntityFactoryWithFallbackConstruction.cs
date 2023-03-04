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
using System.Collections.Concurrent;
using System.Reflection.Emit;

namespace HatTrick.DbEx.Sql.Mapper
{
    public sealed class DefaultEntityFactoryWithFallbackConstruction : IEntityFactory
    {
        #region internals
        private readonly Func<Type, IDbEntity?> factory;
        private readonly ConcurrentDictionary<TypeDictionaryKey, Func<IDbEntity>> ctors = new();
        #endregion

        #region constructors
        public DefaultEntityFactoryWithFallbackConstruction(Func<Type, IDbEntity?> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public TEntity CreateEntity<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
#if !NET5_0_OR_GREATER
            return factory(typeof(TEntity)) as TEntity ?? new TEntity();
#else           
            Type entityType = typeof(TEntity);
            TypeDictionaryKey key = new(entityType.TypeHandle.Value);

            if (ctors.TryGetValue(key, out Func<IDbEntity>? ctor))
            {
                return (ctor!.Invoke() as TEntity)!;
            }

            var entity = factory(entityType);
            if (entity is not null) 
            {
                return (entity as TEntity)!;
            }

            DynamicMethod createEntity = new(
                entityType.FullName!,
                entityType,
                null,
                typeof(DefaultEntityFactoryWithFallbackConstruction).Module,
                false
            );

            ILGenerator il = createEntity.GetILGenerator();
            il.Emit(OpCodes.Newobj, typeof(TEntity).GetConstructor(Type.EmptyTypes)!);
            il.Emit(OpCodes.Ret);

            var addCtor = System.Linq.Expressions.Expression.Lambda<Func<IDbEntity>>(System.Linq.Expressions.Expression.New(entityType)).Compile();
            if (ctors.TryAdd(key, addCtor))
            {
                return (addCtor.Invoke() as TEntity)!;
            }
            return DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<TEntity>();
#endif

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
