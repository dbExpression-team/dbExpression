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
    public class GroupByExpression :
        AnyGroupByExpression,
        IExpressionProvider<IExpressionElement>,
        IEquatable<GroupByExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        #endregion

        #region constructors
        public GroupByExpression(IExpressionElement expression)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region to string
        public override string? ToString() => expression.ToString();
        #endregion

        #region conditional & operator
        public static GroupByExpressionSet operator &(GroupByExpression a, GroupByExpression b) => new(a, b);
        #endregion

        #region equals
        public bool Equals(GroupByExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!expression.Equals(obj.expression)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is GroupByExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ expression.GetHashCode();
                return hash;
            }
        }
        #endregion

        #region implicit operator
        public static implicit operator GroupByExpressionSet(GroupByExpression a) => new(a);

        public static implicit operator GroupByExpression((string TableName, string FieldName) a) => new(new AliasExpression<object?>(a));
        #endregion
    }

}
