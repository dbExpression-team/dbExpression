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

namespace HatTrick.DbEx.Sql.Builder
{
    public class EntityComparisonAssignmentBuilder<TEntity> : EntityFieldAssignmentsContinuation<TEntity>, EntityFieldAssignmentsFromTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly Table<TEntity> entity;
        private IEnumerable<Field> exclusions = Enumerable.Empty<Field>();
        private TEntity? oldStateOfEntity;
        #endregion

        #region constructors
        public EntityComparisonAssignmentBuilder(Table<TEntity> entity)
        {
            this.entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        ///<inheritdoc/>
        EntityFieldAssignmentsFromTermination<TEntity> EntityFieldAssignmentsFromContinuation<TEntity>.From(TEntity oldStateOfEntity)
        {
            this.oldStateOfEntity = oldStateOfEntity ?? throw new ArgumentNullException(nameof(oldStateOfEntity));
            return this;
        }

        ///<inheritdoc/>
        IEnumerable<EntityFieldAssignment> EntityFieldAssignmentsFromTermination<TEntity>.To(TEntity newStateOfEntity)
            => entity.BuildAssignmentExpression(
                oldStateOfEntity!, 
                newStateOfEntity ?? throw new ArgumentNullException(nameof(newStateOfEntity)),
                exclusions
            ).Expressions.Cast<EntityFieldAssignment>();

        EntityFieldAssignmentsFromContinuation<TEntity> EntityFieldAssignmentsContinuation<TEntity>.Exclude(IEnumerable<Field> excludeFromComparison)
        {
            exclusions = excludeFromComparison ?? Enumerable.Empty<Field>();
            return this;
        }

        EntityFieldAssignmentsFromContinuation<TEntity> EntityFieldAssignmentsContinuation<TEntity>.Exclude(params Field[] excludeFromComparison)
        {
            exclusions = excludeFromComparison ?? Enumerable.Empty<Field>();
            return this;
        }
        #endregion
    }
}
