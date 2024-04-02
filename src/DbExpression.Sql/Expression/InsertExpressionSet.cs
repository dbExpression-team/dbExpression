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
    public class InsertExpressionSet : IExpression,
        IExpressionListProvider<InsertExpression>
    {
        #region internals
        protected readonly IEnumerable<InsertExpression> expressions = new List<InsertExpression>();
        #endregion

        #region interface
        public IDbEntity Entity { get; }
        IEnumerable<InsertExpression> IExpressionListProvider<InsertExpression>.Expressions => expressions;
        #endregion

        #region constructors
        protected InsertExpressionSet() { throw new InvalidOperationException("Private constructor does not correctly initialize internal members."); }

        public InsertExpressionSet(IDbEntity entity, IEnumerable<InsertExpression> fields)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            expressions = fields ?? throw new ArgumentNullException(nameof(fields));
        }
        #endregion

        #region to string
        public override string? ToString() => string.Join(", ", expressions.Select(g => g.ToString()));
        #endregion
    }
}
