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
﻿using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InExpression<TValue> : InExpression,
        IEquatable<InExpression<TValue>>
    {
        #region internals
        private readonly IEnumerable<TValue> enumerable;
        private readonly Lazy<List<TValue>> ordered;
        #endregion

        #region constructors
        public InExpression(FieldExpression field, IEnumerable<TValue> values) : base(field, values)
        {
            enumerable = values;
            ordered = new Lazy<List<TValue>>(() => enumerable.OrderBy(x => x).ToList());
        }
        #endregion

        #region equals
        public bool Equals(InExpression<TValue>? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (Field is null && obj.Field is not null) return false;
            if (Field is not null && obj.Field is null) return false;
            if (Field is not null && !Field.Equals(obj.Field)) return false;

            if (!ordered.Value.SequenceEqual(obj.ordered.Value)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is InExpression<TValue> exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Field is not null ? Field.GetHashCode() : 0);
                foreach (var item in ordered.Value)
                    hash = (hash * multiplier) ^ (item is not null ? item.GetHashCode() : 0);

                return hash;
            }
        }
        #endregion
    }
}
