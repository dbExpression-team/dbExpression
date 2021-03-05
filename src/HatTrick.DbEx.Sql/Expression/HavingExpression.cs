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
    public class HavingExpression :
        AnyHavingClause,
        IFilterExpressionElement
    {
        #region interface
        public FilterExpressionSet Expression { get; private set; }
        #endregion

        #region constructors
        private HavingExpression()
        { 
        
        }

        public HavingExpression(FilterExpressionSet havingCondition)
        {
            Expression = havingCondition ?? throw new ArgumentNullException(nameof(havingCondition));
        }
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region conditional & operator
        public static HavingExpression operator &(HavingExpression a, HavingExpression b)
        {
            if (a?.Expression is null)
                return b;

            if (b?.Expression is null)
                return a;

            a.Expression &= new FilterExpressionSet(a.Expression, b.Expression, ConditionalExpressionOperator.And);
            return a;
        }
        #endregion
    }
    
}
