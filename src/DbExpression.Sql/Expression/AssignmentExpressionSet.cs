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
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Expression
{
    public class AssignmentExpressionSet : 
        IExpressionElement,
        IExpressionListProvider<AssignmentExpression>
    {
        #region interface
        public IEnumerable<AssignmentExpression> Expressions { get; private set; } = new List<AssignmentExpression>();
        #endregion

        #region constructors
        public AssignmentExpressionSet()
        {

        }

        public AssignmentExpressionSet(IEnumerable<AssignmentExpression> assignments)
        {
            Expressions = assignments ?? throw new ArgumentNullException(nameof(assignments));
        }

        public AssignmentExpressionSet(AssignmentExpression assignment)
        {
            Expressions = Expressions.Concat(new AssignmentExpression[1] { assignment ?? throw new ArgumentNullException(nameof(assignment)) });
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpressionSet? a, AssignmentExpression? b)
        {
            if (a is null && b is null)
                return new();

            if (a is null)
            {
                a = b!;
            }
            else if (b is not null)
            {
                a.Expressions = a.Expressions.Concat(new AssignmentExpression[1] { b });
            }
            return a;
        }

        public static AssignmentExpressionSet operator &(AssignmentExpressionSet? a, AssignmentExpressionSet? b)
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
