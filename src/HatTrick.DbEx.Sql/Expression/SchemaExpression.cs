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
        protected readonly string identifier;
        protected Dictionary<string, EntityExpression> Entities { get; } = new();
        #endregion

        #region interface
        public string Identifier => identifier;
        IEnumerable<Table> Schema.Entities => Entities.Values;
        #endregion

        #region constructors
        protected SchemaExpression(string identifier)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }
        #endregion

        #region methods
        public override string? ToString()
            => Identifier;
        #endregion

        #region operators
        public static bool operator ==(SchemaExpression? obj1, SchemaExpression? obj2)
            => obj1?.Equals(obj2) ?? false;

        public static bool operator !=(SchemaExpression? obj1, SchemaExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(SchemaExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Identifier.Equals(obj.Identifier)) return false;

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
                hash = (hash * multiplier) ^ (Identifier is not null ? Identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ GetType().GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
