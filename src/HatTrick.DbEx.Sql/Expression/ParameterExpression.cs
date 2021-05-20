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
        IExpressionTypeProvider,
        IEquatable<ParameterExpression>
    {
        #region interface
        public string Name { get; set; }
        public Type DeclaredType { get; private set; }
        public object Value { get; private set; }
        public ParameterDirection Direction { get; set; }
        Type IExpressionTypeProvider.DeclaredType => DeclaredType;
        #endregion

        #region constructors
        protected ParameterExpression(string name, Type declaredType, ParameterDirection direction)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            if (direction == ParameterDirection.Input)
                throw new ArgumentException($"Parameter direction {ParameterDirection.Input} requires a value.");
            Name = name;
            DeclaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            Direction = direction;
        }

        protected ParameterExpression(string name, Type declaredType, object expression, ParameterDirection direction)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            Name = name;
            DeclaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            Value = expression;
            Direction = direction;
        }
        #endregion

        #region tostring
        public override string ToString()
        {
            if (Direction == ParameterDirection.Output)
                return $"{Name} OUTPUT";

            if (Value is null)
                return $"{Name} = null";

            if (Value is DBNull)
                return $"{Name} = DBNull";

            if (Value is string exp)
            {
                if (exp.All(char.IsWhiteSpace))
                    return $"{Name} = '{Value}'";
            }

            return $"{Name} = {Value}";
        }
        #endregion

        #region equals
        public bool Equals(ParameterExpression obj)
        {
            if (obj is null) return false;

            if (Name is null && obj.Name is object) return false;
            if (Name is object && obj.Name is null) return false;
            if (!Name.Equals(obj.Name)) return false;

            if (DeclaredType is null && obj.DeclaredType is object) return false;
            if (DeclaredType is object && obj.DeclaredType is null) return false;
            if (!DeclaredType.Equals(obj.DeclaredType)) return false;

            if (Value is null && obj.Value is object) return false;
            if (Value is object && obj.Value is null) return false;
            if (!Value.Equals(obj.Value)) return false;

            if (Direction != obj.Direction) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is ParameterExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Name is object ? Name.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (DeclaredType is object ? DeclaredType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Value is object ? Value.GetHashCode() : 0);
                hash = (hash * multiplier) ^ Direction.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
