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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class StoredProcedureExpression :
        StoredProcedure,
        IExpressionElement,
        IEquatable<StoredProcedureExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly string name;
        protected readonly SchemaExpression schema;
        protected readonly Action<ISqlOutputParameterList> mapping;
        protected Dictionary<string, QueryParameter> Parameters { get; } = new();
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        Schema StoredProcedure.Schema => schema;
        string IExpressionNameProvider.Name => name;
        IEnumerable<QueryParameter> StoredProcedure.Parameters => Parameters.Values;
        Action<ISqlOutputParameterList> IOutputParameterMappingDelegateProvider.MapDelegate => mapping;
        Type IDatabaseEntityTypeProvider.EntityType => this.GetType();
        #endregion

        #region constructors
        public StoredProcedureExpression(string identifier, string name, SchemaExpression schema)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.mapping = _ => { };
        }

        public StoredProcedureExpression(string identifier, string name, SchemaExpression schema, Action<ISqlOutputParameterList> outputParameterMappingDelegate)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.mapping = outputParameterMappingDelegate ?? throw new ArgumentNullException(nameof(outputParameterMappingDelegate));
        }
        #endregion

        #region to string
        public override string? ToString()
            => identifier;
        #endregion

        #region operators
        public static bool operator ==(StoredProcedureExpression? obj1, StoredProcedureExpression? obj2)
        {
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(StoredProcedureExpression? obj1, StoredProcedureExpression? obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(StoredProcedureExpression? obj)
        {
            if (obj is null) return false;

            if (schema is not null && !schema.Equals(obj.schema)) return false;
            if (identifier != obj.identifier) return false;
            if (name != obj.name) return false;
            if (!Parameters.SequenceEqual(obj.Parameters)) return false;

            //both are as initialized in constructor
            var thisMappingIsNull = mapping.Equals(new Action<ISqlOutputParameterList>(_ => { }));
            var objMappingIsNull = obj.mapping.Equals(new Action<ISqlOutputParameterList>(_ => { }));
            if (!thisMappingIsNull && objMappingIsNull) return false;
            if (thisMappingIsNull && !objMappingIsNull) return false;
            if (thisMappingIsNull && objMappingIsNull) return true;

            if (mapping is not null && !mapping.Equals(obj.mapping)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is StoredProcedureExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is not null ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (schema is not null ? schema.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (name is not null ? name.GetHashCode() : 0);
                foreach (var parameter in Parameters)
                {
                    hash = (hash * multiplier) ^ (parameter.Key is not null ? parameter.Key.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (parameter.Value is not null ? parameter.Value.GetHashCode() : 0);
                }
                return hash;
            }
        }
        #endregion
    }
}
