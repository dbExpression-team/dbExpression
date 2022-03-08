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

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        AnyElement,
        AnyOrderByClause,
        AnyGroupByClause,
        IExpressionTypeProvider,
        ISqlMetadataIdentifierProvider,
        IExpressionNameProvider,
        IExpressionProvider<EntityExpression>,
        IEquatable<FieldExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly Type declaredType;
        protected readonly string name;
        protected readonly EntityExpression entity;
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        string IExpressionNameProvider.Name => name;
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        EntityExpression IExpressionProvider<EntityExpression>.Expression => entity;
        #endregion

        #region constructors
        protected FieldExpression(string identifier, string name, Type declaredType, EntityExpression entity)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            this.entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region to string
        public override string? ToString() => identifier;
        #endregion

        #region order
        public virtual OrderByExpression Asc => new(this, OrderExpressionDirection.ASC);
        public virtual OrderByExpression Desc => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(FieldExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (entity is null && obj.entity is not null) return false;
            if (entity is not null && obj.entity is null) return false;
            if (entity is not null && !entity.Equals(obj.entity)) return false;

            if (declaredType != obj.declaredType) return false;
            if (!StringComparer.Ordinal.Equals(identifier, obj.identifier)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FieldExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is not null ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (entity is not null ? entity.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType is not null ? declaredType.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region operators
        public static implicit operator OrderByExpression(FieldExpression a) => new(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression a) => new(a);

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }
}
