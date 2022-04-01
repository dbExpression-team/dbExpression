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
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpressionSet : 
        IExpressionElement,
        IExpressionListProvider<JoinExpression>,
        IEquatable<JoinExpressionSet>
    {
        #region interface
        public IEnumerable<JoinExpression> Expressions { get; private set; }  = new List<JoinExpression>();
        #endregion

        #region constructors
        private JoinExpressionSet()
        { 
        
        }

        public JoinExpressionSet(JoinExpression joinExpression)
        {
            Expressions = Expressions.Concat(new JoinExpression[1] { joinExpression ?? throw new ArgumentNullException(nameof(joinExpression)) });
        }

        public JoinExpressionSet(JoinExpression aJoinExpression, JoinExpression bJoinExpression)
        {
            Expressions = new List<JoinExpression>
            {
                aJoinExpression ?? throw new ArgumentNullException(nameof(aJoinExpression)),
                bJoinExpression ?? throw new ArgumentNullException(nameof(bJoinExpression))
            };
        }

        public JoinExpressionSet(IEnumerable<JoinExpression> joinExpressions)
        {
            Expressions = joinExpressions ?? throw new ArgumentNullException(nameof(joinExpressions));
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(Environment.NewLine, Expressions.Select(j => j.ToString()));
        #endregion

        #region equals
        public bool Equals(JoinExpressionSet? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!Expressions.SequenceEqual(obj.Expressions)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is JoinExpressionSet exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                foreach (var join in Expressions)
                    hash = (hash * multiplier) ^ (join is not null ? join.GetHashCode() : 0);

                return hash;
            }
        }
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpressionSet? a, JoinExpression? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
            {
                a = new(b!);
            }
            else if (b is not null)
            {
                a.Expressions = a.Expressions.Concat(new JoinExpression[1] { b });
            }
            return a;
        }

        public static JoinExpressionSet operator &(JoinExpressionSet? a, JoinExpressionSet? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
                return b!;

            if (b?.Expressions is null)
                return a;

            a.Expressions = a.Expressions.Concat(b.Expressions);
            return a;
        }
        #endregion
    }
    
}
