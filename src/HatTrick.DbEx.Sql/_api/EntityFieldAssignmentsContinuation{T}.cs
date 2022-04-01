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

﻿using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
 #pragma warning disable IDE1006 // Naming Styles
    public interface EntityFieldAssignmentsContinuation<TEntity>
           where TEntity : class, IDbEntity
 #pragma warning restore IDE1006 // Naming Styles   
    {
        /// <summary>
        /// Continue constructing a list of <see cref="EntityFieldAssignment"/>s.
        /// </summary>
        /// <param name="oldStateOfEntity">The source entity to use for property comparison to develop the list of <see cref="EntityFieldAssignment"/>s.  This is the entity that will be "overwritten".  
        /// </param>
        /// <returns><see cref="EntityFieldAssignmentsContinuation{TEntity}"/>, a fluent builder for constructing a sql UPDATE statement, with a list of "<see cref="HEntityFieldAssignment"/>" constructed from the comparison of the two entity params.</returns>
        EntityFieldAssignmentsFromContinuation<TEntity> From(TEntity oldStateOfEntity);
    }
}
