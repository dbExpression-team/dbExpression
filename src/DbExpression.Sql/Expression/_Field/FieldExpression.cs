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

namespace DbExpression.Sql.Expression
{
    public abstract class FieldExpression :
        Field,
        IEquatable<FieldExpression>
    {
        #region internals
        protected readonly int identifier_a26d3f4b6c1f;
        protected readonly Type declaredType_a26d3f4b6c1f;
        protected readonly string name_a26d3f4b6c1f;
        protected readonly Table entity_a26d3f4b6c1f;
        #endregion

        #region interface
        int ISqlMetadataIdentifierProvider.Identifier => identifier_a26d3f4b6c1f;
        string IExpressionNameProvider.Name => name_a26d3f4b6c1f;
        Type IExpressionTypeProvider.DeclaredType => declaredType_a26d3f4b6c1f;
        Table Field.Table => entity_a26d3f4b6c1f;
        #endregion

        #region constructors
        protected FieldExpression(int identifier_a26d3f4b6c1f, string name_a26d3f4b6c1f, Type declaredType_a26d3f4b6c1f, Table entity_a26d3f4b6c1f)
        {
            this.identifier_a26d3f4b6c1f = identifier_a26d3f4b6c1f;
            this.name_a26d3f4b6c1f = name_a26d3f4b6c1f ?? throw new ArgumentNullException(nameof(name_a26d3f4b6c1f));
            this.declaredType_a26d3f4b6c1f = declaredType_a26d3f4b6c1f ?? throw new ArgumentNullException(nameof(declaredType_a26d3f4b6c1f));
            this.entity_a26d3f4b6c1f = entity_a26d3f4b6c1f ?? throw new ArgumentNullException(nameof(entity_a26d3f4b6c1f));
        }
        #endregion

        #region to string
        public override string? ToString() => name_a26d3f4b6c1f;
        #endregion

        #region order
        public virtual OrderByExpression Asc() => new(this, OrderExpressionDirection.ASC);
        public virtual OrderByExpression Desc() => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(FieldExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (entity_a26d3f4b6c1f is null && obj.entity_a26d3f4b6c1f is not null) return false;
            if (entity_a26d3f4b6c1f is not null && obj.entity_a26d3f4b6c1f is null) return false;
            if (entity_a26d3f4b6c1f is not null && !entity_a26d3f4b6c1f.Equals(obj.entity_a26d3f4b6c1f)) return false;

            if (declaredType_a26d3f4b6c1f != obj.declaredType_a26d3f4b6c1f) return false;
            if (identifier_a26d3f4b6c1f != obj.identifier_a26d3f4b6c1f) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is FieldExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ identifier_a26d3f4b6c1f.GetHashCode();
                hash = (hash * multiplier) ^ (entity_a26d3f4b6c1f is not null ? entity_a26d3f4b6c1f.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType_a26d3f4b6c1f is not null ? declaredType_a26d3f4b6c1f.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region operators
        public static implicit operator OrderByExpression(FieldExpression a) => new(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression a) => new(a);

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2);
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }
}
