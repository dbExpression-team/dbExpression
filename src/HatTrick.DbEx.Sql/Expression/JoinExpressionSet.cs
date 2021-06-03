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
        IExpressionListProvider<JoinExpression>
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
        public override string ToString() => string.Join(Environment.NewLine, Expressions.Select(j => j.ToString()));
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpression b)
        {
            if (aSet is null)
            {
                aSet = new JoinExpressionSet(b);
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new JoinExpression[1] { b });
            }
            return aSet;
        }

        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
