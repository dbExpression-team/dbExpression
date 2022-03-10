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
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringFieldExpression<TEntity> :
        NullableStringFieldExpression,
        IEquatable<NullableStringFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public NullableStringFieldExpression(string identifier, string name, Table entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region in value set
        public override FilterExpressionSet In(params string?[] value) => new(new FilterExpression<bool>(this, new InExpression<string?>(this, value), FilterExpressionOperator.None));
        public override FilterExpressionSet In(IEnumerable<string?> value) => new(new FilterExpression<bool>(this, new InExpression<string?>(this, value), FilterExpressionOperator.None));
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression<TEntity>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableStringFieldExpression<TEntity> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
