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
using System.Data;
using System.Data.Common;

namespace DbExpression.Sql.Expression
{
    public class ParameterizedExpression : IExpressionTypeProvider,
        IEquatable<ParameterizedExpression>
    {
        #region interface
        public Type DeclaredType { get; private set; }
        public DbParameter Parameter { get; private set; }
        public ISqlMetadata? Metadata { get; private set; }
        #endregion

        #region constructors
        public ParameterizedExpression(Type declaredType, DbParameter parameter)
        {
            DeclaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        public ParameterizedExpression(Type declaredType, DbParameter parameter, ISqlMetadata metadata)
        {
            DeclaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            Metadata = metadata;
        }
        #endregion

        #region methods
        public override string? ToString()
            => Parameter.Direction == ParameterDirection.Output ? $"{Parameter.ParameterName} ({Parameter.Direction})" : $"{Parameter.ParameterName} = {Parameter.Value} ({Parameter.Direction})";
        #endregion

        #region equals
        public bool Equals(ParameterizedExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (DeclaredType != obj.DeclaredType) return false;

            if (Parameter is null && obj.Parameter is not null) return false;
            if (Parameter is not null && obj.Parameter is null) return false;
            if (Parameter is not null && !Parameter.Equals(obj.Parameter)) return false;

            if (Metadata is null && obj.Metadata is not null) return false;
            if (Metadata is not null && obj.Metadata is null) return false;
            if (Metadata is not null && !Metadata.Equals(obj.Metadata)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is ParameterizedExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ DeclaredType.GetHashCode();
                hash = (hash * multiplier) ^ (Parameter is not null ? Parameter.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Metadata is not null ? Metadata.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
