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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression : 
        IEntityExpression,
        AnyEntity,
        ISqlMetadataIdentifierProvider,
        IExpressionProvider<SchemaExpression>,
        IExpressionListProvider<FieldExpression>,
        IExpressionAliasProvider,
        IExpressionNameProvider,
        IDbEntityTypeProvider,
        IEquatable<EntityExpression>
   {
        #region internals
        protected readonly string identifier;
        protected readonly string name;
        protected readonly Type dbEntityType;
        protected readonly SchemaExpression schema;
        protected IDictionary<string, FieldExpression> Fields { get; } = new Dictionary<string, FieldExpression>();
        protected readonly string? alias;
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        Type IDbEntityTypeProvider.EntityType => dbEntityType;
        SchemaExpression IExpressionProvider<SchemaExpression>.Expression => schema;
        IEnumerable<FieldExpression> IExpressionListProvider<FieldExpression>.Expressions => Fields.Values;
        string? IExpressionAliasProvider.Alias => alias;
        string IExpressionNameProvider.Name => name;
        #endregion

        #region constructors
        protected EntityExpression()
        {
            throw new InvalidOperationException("Constructor does not initialize properties.");
        }

        protected EntityExpression(string identifier, string name, Type dbEntityType, SchemaExpression schema, string? alias)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.dbEntityType = dbEntityType ?? throw new ArgumentNullException(nameof(dbEntityType));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.alias = alias;
        }
        #endregion

        #region to string
        public override string? ToString() => this.ToString(false);

        public string ToString(bool ignoreAlias = false)
        {
            if (ignoreAlias || string.IsNullOrWhiteSpace(alias))
                return identifier;

            return $"{identifier} AS {alias}";
        }
        #endregion

        #region operators
        public static bool operator ==(EntityExpression? obj1, EntityExpression? obj2)
        {
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(EntityExpression? obj1, EntityExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(EntityExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;

            if (!schema.Equals(obj.schema)) return false;
            if (!StringComparer.Ordinal.Equals(alias, obj.alias)) return false;
            if (!StringComparer.Ordinal.Equals(identifier, obj.identifier)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is EntityExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is not null ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias is not null ? alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
