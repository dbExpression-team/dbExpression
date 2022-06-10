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
    public abstract class FieldExpression<TValue> : FieldExpression,
        IExpressionElement<TValue>,
        AnyElement<TValue>,
        IEquatable<FieldExpression<TValue>>
    {
        #region constructors
        protected FieldExpression(string identifier, string name, Type declaredType, Table entity) : base(identifier, name, declaredType, entity)
        {

        }
        #endregion

        #region as
        public AliasedElement<TValue> As(string alias)
            => new SelectExpression<TValue>(this, alias);
        #endregion

        #region equals
        public bool Equals(FieldExpression<TValue>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is FieldExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region in value set
        public abstract FilterExpression In(params TValue[] value);
        public abstract FilterExpression In(IEnumerable<TValue> value);
        #endregion
    }
}
