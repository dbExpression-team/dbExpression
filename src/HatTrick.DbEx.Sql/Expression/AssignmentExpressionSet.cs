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
    public class AssignmentExpressionSet : 
        IExpressionElement,
        IExpressionSet<AssignmentExpression>
    {
        #region interface
        public IEnumerable<AssignmentExpression> Expressions { get; private set; }
        #endregion

        #region constructors
        public AssignmentExpressionSet()
        {
            Expressions = new List<AssignmentExpression>();
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
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region logical & operator
        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpression b)
        {
            if (aSet is null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new AssignmentExpression[1] { b });
            }
            return aSet;
        }

        public static AssignmentExpressionSet operator &(AssignmentExpressionSet aSet, AssignmentExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
