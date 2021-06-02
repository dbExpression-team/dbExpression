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
        IEntityExpression,
        AnyEntity,
        ISqlMetadataIdentifierProvider,
        IExpressionProvider<SchemaExpression>,
        IExpressionNameProvider,
        IExpressionListProvider<ParameterExpression>,
        IOutputParameterMappingDelegateProvider,
        IEquatable<StoredProcedureExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly string name;
        protected readonly SchemaExpression schema;
        protected readonly IList<ParameterExpression> parameters;
        protected readonly Action<ISqlOutputParameterList> outputParameterMappingDelegate;
        #endregion

        #region interface
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        SchemaExpression IExpressionProvider<SchemaExpression>.Expression => schema;
        string IExpressionNameProvider.Name => name;
        IList<ParameterExpression> IExpressionListProvider<ParameterExpression>.Expressions => parameters;
        Action<ISqlOutputParameterList> IOutputParameterMappingDelegateProvider.MapDelegate => outputParameterMappingDelegate;
        #endregion

        #region constructors
        public StoredProcedureExpression(string identifier, string name, SchemaExpression schema, IList<ParameterExpression> parameters)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.parameters = parameters;
        }

        public StoredProcedureExpression(string identifier, string name, SchemaExpression schema, IList<ParameterExpression> parameters, Action<ISqlOutputParameterList> outputParameterMappingDelegate)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.parameters = parameters;
            this.outputParameterMappingDelegate = outputParameterMappingDelegate ?? throw new ArgumentNullException(nameof(outputParameterMappingDelegate));
        }
        #endregion

        #region to string
        public override string ToString()
            => identifier;
        #endregion

        #region operators
        public static bool operator ==(StoredProcedureExpression obj1, StoredProcedureExpression obj2)
        {
            if (obj1 is null && obj2 is object) return false;
            if (obj1 is object && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(StoredProcedureExpression obj1, StoredProcedureExpression obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(StoredProcedureExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (schema is null && obj.schema is object) return false;
            if (schema is object && obj.schema is null) return false;
            if (!schema.Equals(obj.schema)) return false;

            if (identifier != obj.identifier) return false;
            if (name != obj.name) return false;

            if (parameters is null && obj.parameters is object) return false;
            if (parameters is object && obj.parameters is null) return false;
            if (parameters.SequenceEqual(obj.parameters)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is StoredProcedureExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is object ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (schema is object ? schema.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (name is object ? name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (parameters is object ? parameters.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
