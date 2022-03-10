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

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class AliasExpression :
        AnyElement,
        IExpressionProvider<AliasExpression.AliasExpressionElements>,
        IEquatable<AliasExpression>
    {
        #region internals
        private readonly AliasExpressionElements alias;
        private readonly Type declaredType;
        #endregion

        #region interface
        AliasExpressionElements IExpressionProvider<AliasExpressionElements>.Expression => alias;
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        #endregion

        #region constructors
        public AliasExpression(string tableAlias, string fieldAlias) : this(tableAlias, fieldAlias, typeof(object))
        {

        }

        public AliasExpression(string tableAlias, string fieldAlias, Type declaredType)
        {
            if (string.IsNullOrWhiteSpace(tableAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");
            if (string.IsNullOrWhiteSpace(fieldAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");
            alias = new AliasExpressionElements()
            {
                TableAlias = tableAlias,
                FieldAlias = fieldAlias
            };
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
        }
        #endregion

        #region to string
        public override string? ToString()
            => $"{alias.TableAlias}.{alias.FieldAlias}";
        #endregion

        #region equals
        public bool Equals(AliasExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(alias.TableAlias, obj.alias?.TableAlias)) return false;
            if (!StringComparer.Ordinal.Equals(alias.FieldAlias, obj.alias?.FieldAlias)) return false;

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
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static implicit operator StringExpressionMediator(AliasExpression a) => new(a);
        public static implicit operator NullableStringExpressionMediator(AliasExpression a) => new(a);
        #endregion

        #region classes
        public class AliasExpressionElements : IExpression
        {
            public string TableAlias { get; set; } = String.Empty;
            public string FieldAlias { get; set; } = String.Empty;
        }
        #endregion
    }
}
