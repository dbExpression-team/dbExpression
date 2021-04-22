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

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntityFactoryContinuationConfigurationBuilder
    {
        /// <summary>
        /// Override the default behaviour of creating a new <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="entityFactory">The delegate responsible for creating an instance of a <typeparamref name="TEntity"/>.</param>
        IEntityFactoryContinuationConfigurationBuilder OverrideForEntity<TEntity>(Func<TEntity> entityFactory)
            where TEntity : class, IDbEntity;
    }
}
