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
    public abstract class SchemaExpression :
        Schema,
        IEquatable<SchemaExpression>
    {
        #region internals
        protected readonly SchemaExpressionAttributes Attributes;
        #endregion

        #region interface
        int ISqlMetadataIdentifierProvider.Identifier => Attributes.Identifier;
        IEnumerable<Table> Schema.Entities => Attributes.Entities;
        #endregion

        #region constructors
        protected SchemaExpression(int identifier)
        {
            this.Attributes = new(identifier);
        }
        #endregion

        #region methods
        public override string? ToString()
            => $"[schema:{Attributes.Identifier}]";
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

            if (!Attributes.Equals(obj.Attributes)) return false;

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
                hash = (hash * multiplier) ^ (Attributes is not null ? Attributes.GetHashCode() : 0);
                hash = (hash * multiplier) ^ GetType().GetHashCode();
                return hash;
            }
        }
        #endregion

        #region classes
        public class SchemaExpressionAttributes : IEquatable<SchemaExpressionAttributes>
        {
            #region interface
            public int Identifier { get; }
            public HashSet<EntityExpression> Entities { get; } = new();
            #endregion

            #region constructors
            public SchemaExpressionAttributes(int identifier)
            {
                this.Identifier = identifier;
            }
            #endregion

            #region equals
            public bool Equals(SchemaExpressionAttributes? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(obj, this)) return true;

                if (Identifier != obj.Identifier) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is SchemaExpressionAttributes exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int @base = (int)2166136261;
                    const int multiplier = 16777619;

                    int hash = @base;
                    hash = (hash * multiplier) ^ Identifier.GetHashCode();
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
