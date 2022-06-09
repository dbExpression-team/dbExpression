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
        AliasedElement<T>,
        IEquatable<AliasExpression<T>>
    {
        #region constructors
        public AliasExpression(string singleAlias)
            : base(singleAlias, typeof(T))
        {

        }

        public AliasExpression(string singleAlias, Type declaredType)
            : base(singleAlias, declaredType)
        {

        }

        public AliasExpression((string TableName, string FieldName) alias)
            : base(alias, typeof(T))
        {

        }

        public AliasExpression((string TableName, string FieldName) alias, Type declaredType)
            : base(alias, declaredType)
        {

        }
        #endregion

        #region as
        public AliasedElement<T> As(string alias)
            => new SelectExpression<T>(this, alias);

        AliasedElement<T> AnyElement<T>.As(string alias)
            => new SelectExpression<T>(this, alias);
        #endregion

        #region equals
        public bool Equals(AliasExpression<T>? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (base.Equals(obj)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is AliasExpression<T> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
