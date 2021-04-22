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
    public partial class Int16FieldExpression<TEntity> : 
        Int16FieldExpression,
        IEquatable<Int16FieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public Int16FieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override Int16Element As(string alias)
            => new Int16SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int16FieldExpression<TEntity> obj)
            => obj is Int16FieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is Int16FieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
