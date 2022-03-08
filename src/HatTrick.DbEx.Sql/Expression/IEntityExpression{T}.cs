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

﻿using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEntityExpression<T> : IEntityExpression
        where T : class, IDbEntity
    {
        SelectExpressionSet BuildInclusiveSelectExpression();
        SelectExpressionSet BuildInclusiveSelectExpression(Func<string, string> alias);
        InsertExpressionSet<T> BuildInclusiveInsertExpression(T entity);
        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);
        void HydrateEntity(ISqlFieldReader reader, T entity);
    }
}
