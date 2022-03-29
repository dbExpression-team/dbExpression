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
    public class SelectExpressionSet : 
        IExpressionElement,
        IExpressionListProvider<SelectExpression>
    {
        #region interface
        public IEnumerable<SelectExpression> Expressions { get; private set; } = Enumerable.Empty<SelectExpression>();
        #endregion

        #region constructor
        private SelectExpressionSet()
        {

        }

        public SelectExpressionSet(params SelectExpression[] expressions)
        {
            Expressions = (expressions ?? throw new ArgumentNullException(nameof(expressions))).ToList();
        }

        public SelectExpressionSet(SelectExpression selectExpression)
        {
            Expressions = new SelectExpression[1] { selectExpression ?? throw new ArgumentNullException(nameof(selectExpression)) };
        }

        public SelectExpressionSet(SelectExpressionSet selectExpressionSet)
        {
            Expressions = selectExpressionSet?.Expressions ?? Enumerable.Empty<SelectExpression>();
        }

        public SelectExpressionSet(IEnumerable<SelectExpression> expressions)
        {
            Expressions = expressions ?? throw new ArgumentNullException(nameof(expressions));
        }

        public SelectExpressionSet(SelectExpression aSelectExpression, SelectExpression bSelectExpression)
        {
            Expressions = new SelectExpression[2] {
                aSelectExpression ?? throw new ArgumentNullException(nameof(aSelectExpression)),
                bSelectExpression ?? throw new ArgumentNullException(nameof(bSelectExpression))
            };
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpressionSet? a, SelectExpression? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
            {
                a = b!;
            }
            else if (b is not null)
            {
                a.Expressions = a.Expressions.Concat(new SelectExpression[1] { b });
            }
            return a;
        }

        public static SelectExpressionSet operator &(SelectExpressionSet? a, SelectExpressionSet? b)
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
