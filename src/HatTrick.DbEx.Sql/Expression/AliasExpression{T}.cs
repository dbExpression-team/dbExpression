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

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class AliasExpression<T> : AliasExpression,
        ObjectElement,
        IExpressionElement<object>,
        IExpressionTypeProvider,
        IEquatable<AliasExpression<T>>
    {
        #region internals
        private readonly Type declaredType = typeof(T);
        #endregion

        #region interface
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        #endregion

        #region constructors
        public AliasExpression(string tableAlias, string fieldAlias)
            : base(tableAlias, fieldAlias)
        {

        }

        public AliasExpression(string tableAlias, string fieldAlias, Type declaredType)
            : base(tableAlias, fieldAlias)
        {
            this.declaredType = declaredType ?? throw new ArgumentNullException(nameof(declaredType));
        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(AliasExpression<T> obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (declaredType != obj.declaredType) return false;

            return base.Equals(obj);
        }

        public override bool Equals(object obj)
            => obj is AliasExpression<T> exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (TableAlias is object ? TableAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (FieldAlias is object ? FieldAlias.GetHashCode() : 0);
                hash = (hash * multiplier) ^ declaredType.GetHashCode();
                return hash;
            }
        }
        #endregion
    }
}
