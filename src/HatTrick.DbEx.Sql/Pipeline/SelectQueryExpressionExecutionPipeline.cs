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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SelectQueryExpressionExecutionPipeline : ISelectQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeSelectPipelineExecutionContext> beforeSelect;
        private readonly PipelineEventHook<AfterSelectPipelineExecutionContext> afterSelect;
        #endregion

        #region constructors
        public SelectQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeSelectPipelineExecutionContext> beforeSelect,
            PipelineEventHook<AfterSelectPipelineExecutionContext> afterSelect
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeSelect = beforeSelect;
            this.afterSelect = afterSelect;
        }
        #endregion

        #region methods
        #region entity
        public T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    entity = database.EntityFactory.CreateEntity<T>();
                    var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
                    mapper.Map(row, entity);
                }
            );
            return entity;
        }

        public T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
           where T : class, IDbEntity, new()
        {
            T entity = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        entity = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                }
            );
            return entity;
        }

        public void ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> map)
           where T : class, IDbEntity, new()
        {
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                }
            );
        }

        public T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
           where T : class, IDbEntity, new()
        {
            T entity = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        entity = database.EntityFactory.CreateEntity<T>();
                        map(row, entity);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                }
            );
            return entity;
        }

        public async Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    entity = database.EntityFactory.CreateEntity<T>();
                    var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
                    mapper.Map(row, entity);
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        entity = database.EntityFactory.CreateEntity<T>();
                        map(row, entity);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        entity = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        await map(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }
        public async Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        entity = database.EntityFactory.CreateEntity<T>();
                        await map(row, entity).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }
        #endregion

        #region entity list
        public IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            var entities = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        mapper.Map(row, entity);
                        entities.Add(entity);
                    }
                }
            );
            return entities;
        }

        public IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
        {
            var entities = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var entity = map(row);
                        entities.Add(entity);
                    }
                }
            );
            return entities;
        }

        public void ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> map)
            where T : class, IDbEntity, new()
        {
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        map(row);
                    }
                }
            );
        }

        public IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        map(row, entity);
                        values.Add(entity);
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        mapper.Map(row, entity);
                        values.Add(entity);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }        

        public async Task ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        map(row);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        map(row, entity);
                        values.Add(entity);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as IEntityExpression<T>);
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var entity = map(row);
                        values.Add(entity);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        await map(row).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        await map(row, entity).ConfigureAwait(false);
                        values.Add(entity);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }
        #endregion

        #region value
        public T ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            T value = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                }
            );
            return value;
        }

        public async Task<T> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;

                    var field = row.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }
        
        #endregion

        #region value list
        public IList<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                }
            );
            return values;
        }

        public void ExecuteSelectValueList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<object> read)
        {
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        read(row.ReadField().RawValue);
                    }
                }
            );
        }

        public async Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task ExecuteSelectValueListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<object> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        read(row.ReadField().RawValue);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectValueListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<object, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        await read(row.ReadField().RawValue).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region dynamic
        public dynamic ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            dynamic value = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public void ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
        {
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        read(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                }
            );
        }

        public async Task<dynamic> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            dynamic value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public async Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        read(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        await read(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region dynamic list
        public IList<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                }
            );
            return values;
        }

        public void ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
        {
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        read(row);
                    }
                }
            );
        }

        public async Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        read(row);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        await read(row).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        #endregion

        #region object
        public T ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
        {
            T value = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public async Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken ct)
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        value = await map(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }
        #endregion

        #region object list
        public IList<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        try
                        {
                            var value = map(row);
                            values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value of data reader.", e);
                        }
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        try
                        {
                            var value = map(row);
                            values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value of data reader.", e);
                        }
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        try
                        {
                            var value = await map(row).ConfigureAwait(false);
                            values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value of data reader.", e);
                        }
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }
        #endregion

        private void ExecuteSelectQuery(
            SelectQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand> configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)));

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression);

            beforeSelect?.Invoke(new Lazy<BeforeSelectPipelineExecutionContext>(() => new BeforeSelectPipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)));

            var reader = executor.ExecuteQuery(
                statement, 
                connection,
                new SqlStatementValueConverterProvider(database.ValueConverterFactory, expression.Select),
                cmd => {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            if (reader is null)
                return;

            transform(reader);

            afterSelect?.Invoke(new Lazy<AfterSelectPipelineExecutionContext>(() => new AfterSelectPipelineExecutionContext(database, expression)));
        }

        private async Task ExecuteSelectQueryAsync(
            SelectQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand> configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, expression);

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeSelect is object)
            {
                await beforeSelect.InvokeAsync(new Lazy<BeforeSelectPipelineExecutionContext>(() => new BeforeSelectPipelineExecutionContext(database, expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var executor = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression);

            var reader = await executor.ExecuteQueryAsync(
                statement,
                connection,
                new SqlStatementValueConverterProvider(database.ValueConverterFactory, expression.Select),
                async cmd =>
                {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statementBuilder.CreateSqlStatement())), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (afterExecution is object)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            if (reader is null)
                return;

            await transform(reader).ConfigureAwait(false);

            if (afterSelect is object)
            {
                await afterSelect.InvokeAsync(new Lazy<AfterSelectPipelineExecutionContext>(() => new AfterSelectPipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }
    }
    #endregion
}
