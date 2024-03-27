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

using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.Sql.Configuration
{
    public interface IEntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="mapping">The delegate that iterates a field reader and maps the field values to <typeparamref name="TEntity"/> properties.</typeparam>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Action<ISqlFieldReader, TEntity> mapping);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="T">The entity mapper type to use for mapping data to an <see cref="TEntity"/>.</typeparam>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : class, IEntityMapper<TEntity>;

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="mapper">The entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(IEntityMapper<TEntity> mapper);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="factory">A delegate that returns an entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IEntityMapper<TEntity>> factory);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="factory">A delegate that returns an entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IEntityMapper<TEntity>> factory);
    }
}
