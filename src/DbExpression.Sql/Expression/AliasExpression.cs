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
    public partial class AliasExpression :
        AliasedElement,
        IExpressionProvider<AliasExpression.AliasExpressionElements>,
        IExpressionTypeProvider,
        IEquatable<AliasExpression>
    {
        #region internals
        protected readonly AliasExpressionElements alias;
        private readonly Type declaredType;
        #endregion

        #region interface
        AliasExpressionElements IExpressionProvider<AliasExpressionElements>.Expression => alias;
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        #endregion

        #region constructors
        public AliasExpression(string singleAlias, Type declaredType)
        {
            alias = new AliasExpressionElements()
            {
                FieldAlias = singleAlias
            };
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
        }

        protected AliasExpression((string TableName, string FieldName) aliased, Type declaredType)
        {
            if (aliased == default((string, string)))
                throw new ArgumentException($"{nameof(aliased)} is required.");
            if (string.IsNullOrWhiteSpace(aliased.TableName))
                throw new ArgumentException($"{nameof(aliased.TableName)} is required.");
            if (string.IsNullOrWhiteSpace(aliased.FieldName))
                throw new ArgumentException($"{nameof(aliased.FieldName)} is required.");
            alias = new AliasExpressionElements()
            {
                TableAlias = aliased.TableName,
                FieldAlias = aliased.FieldName
            };
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
        }
        #endregion

        #region order
        public virtual OrderByExpression Asc() => new(this, OrderExpressionDirection.ASC);
        public virtual OrderByExpression Desc() => new(this, OrderExpressionDirection.DESC);
        #endregion

        #region to string
        public override string? ToString()
        {
            if (string.IsNullOrWhiteSpace(alias.TableAlias))
                return $"\"{alias.FieldAlias}\"";
            return $"\"{alias.TableAlias}\".\"{alias.FieldAlias}\"";
        }
        #endregion

        #region equals
        public bool Equals(AliasExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(alias.TableAlias, obj.alias?.TableAlias)) return false;
            if (!StringComparer.Ordinal.Equals(alias.FieldAlias, obj.alias?.FieldAlias)) return false;
            if (declaredType != obj.declaredType) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is AliasExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (alias.TableAlias is not null ? alias.TableAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias.FieldAlias is not null ? alias.FieldAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType is not null ? declaredType.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class AliasExpressionElements : IExpressionElement
        {
            public string? TableAlias { get; set; }
            public string FieldAlias { get; set; } = string.Empty;
        }
        #endregion
    }
}
