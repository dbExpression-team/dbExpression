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
        protected readonly StoredProcedureExpressionAttributes Attributes;
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => Attributes.Identifier;
        Schema StoredProcedure.Schema => Attributes.Schema;
        string IExpressionNameProvider.Name => Attributes.Name;
        IEnumerable<QueryParameter> StoredProcedure.Parameters => Attributes.Parameters.Values;
        Action<ISqlOutputParameterList> IOutputParameterMappingDelegateProvider.MapDelegate => Attributes.Mapping;
        Type IDatabaseEntityTypeProvider.EntityType => this.GetType();
        #endregion

        #region constructors
        public StoredProcedureExpression(string identifier, string name, Schema schema)
        {
            this.Attributes = new(identifier, name, schema, _ => { });
        }

        public StoredProcedureExpression(string identifier, string name, Schema schema, Action<ISqlOutputParameterList> outputParameterMappingDelegate)
        {
            this.Attributes = new(identifier, name, schema, outputParameterMappingDelegate ?? throw new ArgumentNullException(nameof(outputParameterMappingDelegate)));
        }
        #endregion

        #region to string
        public override string? ToString()
            => Attributes.Identifier;
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
            if (ReferenceEquals(obj, this)) return true;

            if (!Attributes.Equals(obj.Attributes)) return false;
            if (!GetType().Equals(obj.GetType())) return false;

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
                hash = (hash * multiplier) ^ (Attributes is not null ? Attributes.GetHashCode() : 0);
                hash = (hash * multiplier) ^ GetType().GetHashCode();
                return hash;
            }
        }
        #endregion

        #region classes
        public class StoredProcedureExpressionAttributes : IEquatable<StoredProcedureExpressionAttributes>
        {
            #region interface
            public string Identifier { get; }
            public string Name { get; }
            public Schema Schema { get; }
            public Action<ISqlOutputParameterList> Mapping { get; }
            public Dictionary<string, QueryParameter> Parameters { get; } = new();
            #endregion

            #region constructors
            public StoredProcedureExpressionAttributes(string identifier, string name, Schema schema, Action<ISqlOutputParameterList> outputParameterMappingDelegate)
            {
                this.Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
                this.Name = name ?? throw new ArgumentNullException(nameof(name));
                this.Schema = schema ?? throw new ArgumentNullException(nameof(schema));
                this.Mapping = outputParameterMappingDelegate ?? throw new ArgumentNullException(nameof(outputParameterMappingDelegate));
            }
            #endregion

            #region equals
            public bool Equals(StoredProcedureExpressionAttributes? obj)
            {
                if (obj is null) return false;

                if (Identifier != obj.Identifier) return false;
                if (Name != obj.Name) return false;
                if (Schema is not null && !Schema.Equals(obj.Schema)) return false;
                if (!Parameters.SequenceEqual(obj.Parameters)) return false;

                //both are as initialized in constructor
                var thisMappingIsNull = Mapping is null || Mapping.Equals(new Action<ISqlOutputParameterList>(_ => { }));
                var objMappingIsNull = obj.Mapping is null || obj.Mapping.Equals(new Action<ISqlOutputParameterList>(_ => { }));
                if (!thisMappingIsNull && objMappingIsNull) return false;
                if (thisMappingIsNull && !objMappingIsNull) return false;
                if (thisMappingIsNull && objMappingIsNull) return true;

                if (Mapping is not null && !Mapping.Equals(obj.Mapping)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is StoredProcedureExpressionAttributes exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int @base = (int)2166136261;
                    const int multiplier = 16777619;

                    int hash = @base;
                    hash = (hash * multiplier) ^ (Identifier is not null ? Identifier.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Name is not null ? Name.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Schema is not null ? Schema.GetHashCode() : 0);
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
        #endregion
    }
}
