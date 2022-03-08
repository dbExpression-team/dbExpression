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
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ParameterExpression :
        IExpressionElement,
        ISqlMetadataIdentifierProvider,
        IExpressionNameProvider,
        IExpressionTypeProvider,
        IEquatable<ParameterExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly Type declaredType;
        protected readonly string name;
        #endregion

        #region interface
        public object? Value { get; private set; }
        public ParameterDirection Direction { get; set; }
        string ISqlMetadataIdentifierProvider.Identifier => identifier;
        string IExpressionNameProvider.Name => name;
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        #endregion

        #region constructors
        protected ParameterExpression(string identifier, string name, Type declaredType, ParameterDirection direction)
            : this(identifier, name, declaredType, null, direction)
        {

        }

        protected ParameterExpression(string identifier, string name, Type declaredType, object? expression, ParameterDirection direction)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            Value = expression;
            Direction = direction;
        }
        #endregion

        #region tostring
        public override string? ToString()
        {
            if (Direction == ParameterDirection.Output)
                return $"{name} OUTPUT";

            if (Value is null)
                return $"{name} = null";

            if (Value is DBNull)
                return $"{name} = DBNull";

            if (Value is string exp)
            {
                if (exp.All(char.IsWhiteSpace))
                    return $"{name} = '{Value}'";
            }

            return $"{name} = {Value}";
        }
        #endregion

        #region equals
        public bool Equals(ParameterExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!name.Equals(obj.name)) return false;
            if (!declaredType.Equals(obj.declaredType)) return false;

            if (Value is null && obj.Value is not null) return false;
            if (Value is not null && obj.Value is null) return false;
            if (Value is not null && !Value.Equals(obj.Value)) return false;

            if (!Direction.Equals(obj.Direction)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is ParameterExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (name is not null ? name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType is not null ? declaredType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Value is not null ? Value.GetHashCode() : 0);
                hash = (hash * multiplier) ^ Direction.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
