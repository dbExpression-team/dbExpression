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
    public class OrderByExpression :
        AnyOrderByClause
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        public OrderExpressionDirection Direction { get; private set; }
        #endregion

        #region constructors
        public OrderByExpression(IExpressionElement orderBy, OrderExpressionDirection direction)
        {
            Expression = orderBy ?? throw new ArgumentNullException(nameof(orderBy));
            Direction = direction;
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression} {Direction}";
        #endregion

        #region conditional & operator
        public static OrderByExpressionSet operator &(OrderByExpression a, OrderByExpression b) => new OrderByExpressionSet(a, b);
        #endregion

        #region implicit order by expression set operator
        public static implicit operator OrderByExpressionSet(OrderByExpression a) => new OrderByExpressionSet(a);
        #endregion
    }
    
}
