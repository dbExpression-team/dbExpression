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
        IExpressionElement,
        AnyOrderByClause,
        AnyGroupByClause,
        IExpressionProvider<AliasExpression.AliasSpecification>,
        IEquatable<AliasExpression>
    {
        #region internals
        private readonly AliasSpecification specification;
        #endregion

        #region interface
        AliasSpecification IExpressionProvider<AliasSpecification>.Expression => specification;
        #endregion

        #region constructors
        public AliasExpression(string tableAlias, string fieldAlias)
        {
            if (string.IsNullOrWhiteSpace(tableAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");
            if (string.IsNullOrWhiteSpace(fieldAlias))
                throw new ArgumentException($"{nameof(tableAlias)} is required.");
            specification = new AliasSpecification()
            {
                TableAlias = tableAlias,
                FieldAlias = fieldAlias
            };
        }
        #endregion

        #region to string
        public override string ToString()
            => $"{specification.TableAlias}.{specification.FieldAlias}";
        #endregion

        #region equals
        public bool Equals(AliasExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!StringComparer.Ordinal.Equals(specification.TableAlias, obj.specification.TableAlias)) return false;
            if (!StringComparer.Ordinal.Equals(specification.FieldAlias, obj.specification.FieldAlias)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is AliasExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (specification.TableAlias is object ? specification.TableAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (specification.FieldAlias is object ? specification.FieldAlias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class AliasSpecification : IExpression
        { 
            public string TableAlias { get; set; }
            public string FieldAlias { get; set; }
        }
        #endregion
    }
}
