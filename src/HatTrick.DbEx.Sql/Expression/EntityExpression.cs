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
        Table,
        IEquatable<EntityExpression>
   {
        #region internals
        protected readonly EntityExpressionAttributes Attributes;
        #endregion

        #region interface
        Schema Table.Schema => Attributes.Schema;
        IEnumerable<Field> Table.Fields => Attributes.Fields.Values;
        string ISqlMetadataIdentifierProvider.Identifier => Attributes.Identifier;
        Type IDatabaseEntityTypeProvider.EntityType => Attributes.Type;
        string? IExpressionAliasProvider.Alias => Attributes.Alias;
        string IExpressionNameProvider.Name => Attributes.Name;
        #endregion

        #region constructors
        protected EntityExpression()
        {
            throw new InvalidOperationException("Constructor does not initialize properties.");
        }

        protected EntityExpression(string identifier, string name, Type dbEntityType, Schema schema, string? alias)
        {
            this.Attributes = new(identifier, name, dbEntityType, schema, alias);
        }
        #endregion

        #region methods
        SelectExpressionSet Table.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        SelectExpressionSet Table.BuildInclusiveSelectExpression(Func<string, string> alias)
            => GetInclusiveSelectExpression(alias);
        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
        protected abstract SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias);
        #endregion

        #region to string
        public override string? ToString() => this.ToString(false);

        public string ToString(bool ignoreAlias = false)
        {
            if (ignoreAlias || string.IsNullOrWhiteSpace(Attributes.Alias))
                return Attributes.Identifier;

            return $"{Attributes.Identifier} AS {Attributes.Alias}";
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

            if (!Attributes.Equals(obj.Attributes)) return false;

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
                hash = (hash * multiplier) ^ (Attributes is not null ? Attributes.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class EntityExpressionAttributes : IEquatable<EntityExpressionAttributes>
        {
            #region interface
            public string Identifier { get; }
            public string Name { get; }
            public Schema Schema { get; }
            public Type Type { get; }
            public string? Alias { get; }
            public Dictionary<string, Field> Fields { get; } = new();
            #endregion

            #region constructors
            public EntityExpressionAttributes(string identifier, string name, Type type, Schema schema, string? alias)
            {
                this.Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
                this.Name = name ?? throw new ArgumentNullException(nameof(name));
                this.Type = type ?? throw new ArgumentNullException(nameof(type));
                this.Schema = schema ?? throw new ArgumentNullException(nameof(schema));
                this.Alias = alias;
            }
            #endregion

            #region equals
            public bool Equals(EntityExpressionAttributes? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(obj, this)) return true;

                if (!Schema.Equals(obj.Schema)) return false;
                if (!Type.Equals(obj.Type)) return false;
                if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;
                if (!StringComparer.Ordinal.Equals(Identifier, obj.Identifier)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is EntityExpressionAttributes exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int @base = (int)2166136261;
                    const int multiplier = 16777619;

                    int hash = @base;
                    hash = (hash * multiplier) ^ (Identifier is not null ? Identifier.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Type is not null ? Type.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Schema is not null ? Schema.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Alias is not null ? Alias.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
