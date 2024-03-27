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
    public abstract class SchemaExpression :
        Schema,
        IEquatable<SchemaExpression>
    {
        #region internals
        protected readonly int dbex_identifier;
        protected readonly string dbex_name;
        protected readonly Type dbex_schemaType;
        protected readonly HashSet<Table> dbex_entities = new();
        #endregion

        #region interface
        int ISqlMetadataIdentifierProvider.Identifier => dbex_identifier;
        string IExpressionNameProvider.Name => dbex_name;
        Type IDatabaseEntityTypeProvider.EntityType => dbex_schemaType;
        IEnumerable<Table> Schema.Entities => dbex_entities;
        #endregion

        #region constructors
        protected SchemaExpression(int dbex_identifier, string dbex_name, Type dbex_schemaType)
        {
            this.dbex_identifier = dbex_identifier;
            this.dbex_name = dbex_name;
            this.dbex_schemaType = dbex_schemaType;
        }
        #endregion

        #region methods
        protected void AddEntity(Table dbex_entity)
        {
            dbex_entities.Add(dbex_entity);
        }

        public override string? ToString()
            => $"[{dbex_name}]";
        #endregion

        #region operators
        public static bool operator ==(SchemaExpression? obj1, SchemaExpression? obj2)
        {
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(SchemaExpression? obj1, SchemaExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(SchemaExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!dbex_identifier.Equals(obj.dbex_identifier)) return false;
            if (!dbex_name.Equals(obj.dbex_name)) return false;
            if (!dbex_schemaType.Equals(obj.dbex_schemaType)) return false;

            if (GetType() != obj.GetType()) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is SchemaExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ dbex_identifier.GetHashCode();
                hash = (hash * multiplier) ^ (dbex_name is not null ? dbex_name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (dbex_schemaType is not null ? dbex_schemaType.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
