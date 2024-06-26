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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExpression.Sql.Expression
{
    public abstract class InExpression :
        IExpressionElement,
        IEquatable<InExpression>
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        public IEnumerable Values { get; private set; }
        #endregion

        #region constructors
        protected InExpression(IExpressionElement expression, IEnumerable values)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Values = values ?? throw new ArgumentNullException(nameof(values));
        }
        #endregion

        #region tostring
        public override string? ToString()
        {
            if (Expression is null)
                return "null";

            var builder = new StringBuilder("In(");
            var enumerator = Values.GetEnumerator();
            var firstElement = true;
            while (enumerator.MoveNext())
            {
                if (!firstElement)
                {
                    builder.Append(',');
                }
                firstElement = false;
                builder.Append(enumerator.Current);
            }
            builder.Append(")");

            return builder.ToString();
        }
        #endregion

        #region equals
        public bool Equals(InExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (Expression is null && obj.Expression is not null) return false;
            if (Expression is not null && obj.Expression is null) return false;
            if (Expression is not null && !Expression.Equals(obj.Expression)) return false;

            if (!Values.Equals(obj.Values)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is InExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Values is not null ? Values.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
