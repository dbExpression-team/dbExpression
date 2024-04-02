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

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Expression
{
    public abstract class EntityExpression : 
        Table,
        IEquatable<EntityExpression>
   {
        #region internals
        protected readonly int dbex_identifier;
        protected readonly Type dbex_entityType;
        protected readonly string dbex_name;
        protected readonly Schema dbex_schema;
        private readonly HashSet<Field> fields_dbex = new();
        protected readonly string? dbex_alias;
        #endregion

        #region interface
        int ISqlMetadataIdentifierProvider.Identifier => dbex_identifier;
        string IExpressionNameProvider.Name => dbex_name;
        Type IDatabaseEntityTypeProvider.EntityType => dbex_entityType;
        Schema Table.Schema => dbex_schema;
        IEnumerable<Field> Table.Fields => fields_dbex;
        string? IExpressionAliasProvider.Alias => dbex_alias;
        #endregion

        #region constructors
        protected EntityExpression()
        {
            throw new InvalidOperationException("Constructor does not initialize properties.");
        }

        protected EntityExpression(int dbex_identifier, string dbex_name, Type dbex_entityType, Schema dbex_schema, string? dbex_alias)
        {
            this.dbex_identifier = dbex_identifier;
            this.dbex_name = dbex_name ?? throw new ArgumentNullException(nameof(dbex_name));
            this.dbex_entityType = dbex_entityType ?? throw new ArgumentNullException(nameof(dbex_entityType));
            this.dbex_schema = dbex_schema ?? throw new ArgumentNullException(nameof(dbex_schema));
            this.dbex_alias = dbex_alias;
        }
        #endregion

        #region methods
        protected void AddField(Field field_dbex)
        { 
            fields_dbex.Add(field_dbex);
        }

        SelectExpressionSet Table.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        SelectExpressionSet Table.BuildInclusiveSelectExpression(Func<string, string> dbex_alias)
            => GetInclusiveSelectExpression(dbex_alias);
        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
        protected abstract SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> dbex_alias);
        #endregion

        #region to string
        public override string? ToString() => this.ToString(false);

        public string ToString(bool ignoreAlias = false)
        {
            if (ignoreAlias || string.IsNullOrWhiteSpace(dbex_alias))
                return dbex_name;

            return $"{dbex_name} AS {dbex_alias}";
        }
        #endregion

        #region operators
        public static bool operator ==(EntityExpression? obj1_dbex, EntityExpression? obj2_dbex)
        {
            if (obj1_dbex is not null && obj2_dbex is null) return false;
            if (obj1_dbex is null && obj2_dbex is not null) return false;
            if (obj1_dbex is null && obj2_dbex is null) return true;

            return obj1_dbex!.Equals(obj2_dbex);
        }

        public static bool operator !=(EntityExpression? obj1_dbex, EntityExpression? obj2_dbex)
            => !(obj1_dbex == obj2_dbex);
        #endregion

        #region equals
        public bool Equals(EntityExpression? obj_dbex)
        {
            if (obj_dbex is null) return false;
            if (ReferenceEquals(obj_dbex, this)) return true;

            if (dbex_identifier != obj_dbex.dbex_identifier) return false;
            if (!dbex_name.Equals(obj_dbex.dbex_name)) return false;
            if (!dbex_entityType.Equals(obj_dbex.dbex_entityType)) return false;
            if (!dbex_schema.Equals(obj_dbex.dbex_schema)) return false;
            if (!StringComparer.Ordinal.Equals(dbex_alias, obj_dbex.dbex_alias)) return false;

            return true;
        }

        public override bool Equals(object? obj_dbex)
            => obj_dbex is EntityExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ dbex_identifier.GetHashCode();
                hash = (hash * multiplier) ^ (dbex_name is not null ? dbex_name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (dbex_entityType is not null ? dbex_entityType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (dbex_schema is not null ? dbex_schema.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (dbex_alias is not null ? dbex_alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
