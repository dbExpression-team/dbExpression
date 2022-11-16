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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public sealed class SelectQueryExpressionExecutionPipeline :
        ISelectQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly ILogger<SelectQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly IValueConverterFactory valueConverterFactory;
        private readonly IMapperFactory mapperFactory;
        private readonly IEntityFactory entityFactory;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventSubscriptions events;
        #endregion

        #region constructors
        public SelectQueryExpressionExecutionPipeline(
            ILogger<SelectQueryExpressionExecutionPipeline> logger,
            IDbConnectionFactory connectionFactory,
            ISqlStatementExecutor statementExecutor,
            IValueConverterFactory valueConverterFactory,
            IMapperFactory mapperFactory,
            IEntityFactory entityFactory,
            ISqlStatementBuilder statementBuilder,
            PipelineEventSubscriptions events
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
            this.entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        #region entity
        public TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity, new()
        {
            TEntity? entity = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    entity = entityFactory.CreateEntity<TEntity>();
                    if (entity is null)
                        return;

                    var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                    mapper.Map(row, entity);
                }
            );
            return entity;
        }

        public TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity?> map)
           where TEntity : class, IDbEntity
        {
            TEntity? entity = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                }
            );
            return entity;
        }

        public void ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> map)
           where TEntity : class, IDbEntity
        {
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                }
            );
        }

        public TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
           where TEntity : class, IDbEntity, new()
        {
            TEntity? entity = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        map(row, entity);
                    }
                    catch (Exception e)
                    {
                        if (e is DbExpressionException)
                            throw;
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                }
            );
            return entity;
        }

        public async Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            TEntity? entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                        mapper.Map(row, entity);
                    }
                    catch (Exception e)
                    {
                        if (e is DbExpressionException)
                            throw;
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> map, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            TEntity? entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = entityFactory.CreateEntity<TEntity>()
                            ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        map(row, entity);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity?> map, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            TEntity? entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }

        public async Task ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        await map(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            TEntity? entity = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        await map(row, entity).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return entity;
        }
        #endregion

        #region entity list
        public IEnumerable<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        mapper.Map(row, entity);
                        entities.Add(entity);
                    }
                    reader.Close();
                }
            );
            return entities;
        }

        public IEnumerable<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity?> map)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            var entity = map(row);
                            if (entity is not null)
                                entities.Add(entity);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                }
            );
            return entities;
        }

        public void ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> map)
            where TEntity : class, IDbEntity
        {
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            map(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                }
            );
        }

        public IEnumerable<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        try
                        {
                            map(row, entity);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                        entities.Add(entity);
                    }
                    reader.Close();
                }
            );
            return entities;
        }

        public async Task<IEnumerable<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        mapper.Map(row, entity);
                        entities.Add(entity);
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return entities;
        }

        public async Task ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> map, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            map(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            var values = new List<TEntity>();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        try
                        {
                            map(row, entity);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                        values.Add(entity);
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task<IEnumerable<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            var mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            var entity = map(row);
                            entities.Add(entity);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return entities;
        }

        public async Task ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            await map(row).ConfigureAwait(false);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            var entities = new List<TEntity>();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                        try
                        {
                            await map(row, entity).ConfigureAwait(false);
                            entities.Add(entity);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping data reader to entity {typeof(TEntity)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return entities;
        }

        public async IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            IEntityMapper<TEntity>? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                if (mapper is null)
                    mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                mapper.Map(row, entity);
                yield return entity;
            }
        }

        public async IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, [EnumeratorCancellation] CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            IEntityMapper<TEntity>? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                if (mapper is null)
                    mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                map(row, entity);
                yield return entity;
            }
        }

        public async IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, [EnumeratorCancellation] CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            IEntityMapper<TEntity>? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                if (mapper is null)
                    mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                var entity = map(row);
                yield return entity;
            }
        }

        public async IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, [EnumeratorCancellation] CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            IEntityMapper<TEntity>? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var entity = entityFactory.CreateEntity<TEntity>() ?? throw new DbExpressionException($"Expected entity factory to provide an entity of type {typeof(TEntity)}.");
                if (mapper is null)
                    mapper = mapperFactory.CreateEntityMapper(table ?? throw new ArgumentNullException(nameof(table)));
                await map(row, entity).ConfigureAwait(false);
                yield return entity;
            }
        }
        #endregion

        #region value
        public T? ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            T? value = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    reader.Close();
                    if (field is null)
                        return;

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T?> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            T? value = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    var field = row.ReadField();
                    if (field is null)
                        return;

                    try
                    {
                        value = field.GetValue<T>();
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        #endregion

        #region value list
        public IEnumerable<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        try
                        {
                            values.Add(field.GetValue<T>());
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public void ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<T?> read)
        {
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        T? value = default;
                        try
                        {
                            value = field.GetValue<T>();
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }
                        try
                        {
                            read(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the value", e);
                        }
                    }
                    reader.Close();
                }
            );
        }

        public async Task<IEnumerable<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        try
                        {
                            values.Add(field.GetValue<T>()!);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async Task ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<T?> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        T? value = default;
                        try
                        {
                            value = field.GetValue<T>();
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }

                        try
                        {
                            read(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the value", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<T?, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        T? value = default;
                        try
                        {
                            value = field.GetValue<T>();
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error converting value to {typeof(T)}, actual type in reader is {field.DataType}.", e);
                        }

                        try
                        {
                            await read(value).ConfigureAwait(false);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the value", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        public async IAsyncEnumerable<T> ExecuteSelectValueListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var field = row.ReadField();
                if (field is not null)
                    yield return field.GetValue<T>();
            }
        }

        #endregion

        #region dynamic
        public dynamic? ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            dynamic? value = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public void ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
        {
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        read(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                    }
                }
            );
        }

        public async Task<dynamic?> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            dynamic? value = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;

                    reader.Close();

                    value = new ExpandoObject();
                    var mapper = mapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public async Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        read(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        await read(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region dynamic list
        public IEnumerable<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = mapperFactory.CreateExpandoObjectMapper();
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public void ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
        {
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            read(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                        }
                    }
                    reader.Close();
                }
            );
        }

        public async Task<IEnumerable<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = mapperFactory.CreateExpandoObjectMapper();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async IAsyncEnumerable<dynamic> ExecuteSelectDynamicListAsyncEnumerable(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, [EnumeratorCancellation] CancellationToken ct)
        {
            IExpandoObjectMapper? mapper = null;
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var value = new ExpandoObject();
                if (mapper is null)
                    mapper = mapperFactory.CreateExpandoObjectMapper() ?? throw new DbExpressionException("Could not resolve a mapper for mapping dynamic objects.");
                mapper.Map(value, row);
                yield return value;
            }
        }

        public async Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            read(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        public async Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
        {
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            await read(row).ConfigureAwait(false);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException("Error occurred in the delegate managing the field reader.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
        }

        #endregion

        #region object
        public T? ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map)
        {
            T? value = default;
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T?> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct)
        {
            T? value = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public async Task<T?> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct)
        {
            T? value = default;
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    reader.Close();
                    if (row is null)
                        return;

                    try
                    {
                        value = await map(row).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }
        #endregion

        #region object list
        public IEnumerable<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = reader.ReadRow()) is not null)
                    {
                        try
                        {
                            var value = map(row);
                            if (value is not null)
                                values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                        }
                    }
                    reader.Close();
                }
            );
            return values;
        }

        public async Task<IEnumerable<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            var value = map(row);
                            if (value is not null)
                                values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var value = map(row);
                if (value is not null)
                    yield return value;
            }
        }

        public async Task<IEnumerable<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlFieldReader? row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
                    {
                        try
                        {
                            var value = await map(row).ConfigureAwait(false);
                            if (value is not null)
                                values.Add(value);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error occurred in the delegate mapping the field reader to a {typeof(T)}.", e);
                        }
                    }
                    reader.Close();
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public async IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (ISqlFieldReader row in ExecuteSelectQueryAsyncEnumerable(
                expression,
                new SqlStatementValueConverterProvider(valueConverterFactory, expression.Select),
                connection,
                configureCommand,
                ct
            ))
            {
                var value = await map(row).ConfigureAwait(false);
                if (value is not null)
                    yield return value;
            }
        }
        #endregion

        #region exec
        private void ExecuteSelectQuery(
            SelectQueryExpression expression,
            IValueConverterProvider valueConverterProvider,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            OnBeforeStart(expression);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for select query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a select query without a sql statement.");

            OnAfterAssembly(expression, statementBuilder, statement);

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                var reader = statementExecutor.ExecuteQuery(
                    statement,
                    local,
                    valueConverterProvider,
                    cmd =>
                    {
                        OnBeforeCommand(expression, cmd, statement);
                        configureCommand?.Invoke(cmd);
                    },
                    cmd => OnAfterCommand(expression, cmd)
                );

                if (reader is null)
                    return;

                transform(reader);
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            OnAfterComplete(expression);
        }

        private async Task ExecuteSelectQueryAsync(
            SelectQueryExpression expression,
            IValueConverterProvider valueConverterProvider,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for select query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a select query without a sql statement.");

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                var reader = await statementExecutor.ExecuteQueryAsync(
                    statement,
                    local,
                    valueConverterProvider,
                    async cmd =>
                    {
                        await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);

                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd => await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false),
                    ct
                ).ConfigureAwait(false);

                if (reader is null)
                    return;

                ct.ThrowIfCancellationRequested();

                await transform(reader).ConfigureAwait(false);
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);
        }

        private async IAsyncEnumerable<ISqlFieldReader> ExecuteSelectQueryAsyncEnumerable(
            SelectQueryExpression expression,
            IValueConverterProvider valueConverterProvider,
            ISqlConnection? connection,
            Action<IDbCommand>? configureCommand,
            [EnumeratorCancellation] CancellationToken ct
        )
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for select query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a select query without a sql statement.");

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                await foreach (ISqlFieldReader row in statementExecutor.ExecuteQueryAsyncEnumerable(
                    statement,
                    local,
                    valueConverterProvider,
                    async cmd =>
                    {
                        await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);

                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd => await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false),
                    ct
                ))
                {
                    yield return row;
                };
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);
        }

        #region events
        #region sync
        private void OnBeforeStart(SelectQueryExpression expression)
        {
            if (events.OnBeforeStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before start events for select query.");
                events.OnBeforeStart.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
            }
            if (events.OnBeforeSelectStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before select start events for select query.");
                events.OnBeforeSelectStart.Invoke(new Lazy<BeforeSelectStartPipelineEventContext>(() => new BeforeSelectStartPipelineEventContext(expression, statementBuilder.Parameters)));
            }
        }

        private void OnAfterAssembly(SelectQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement)
        {
            if (events.OnAfterSelectAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select assembly events for select query.");
                events.OnAfterSelectAssembly?.Invoke(new Lazy<AfterSelectAssemblyPipelineEventContext>(() => new AfterSelectAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
            }
            if (events.OnAfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for select query.");
                events.OnAfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
            }
        }

        private void OnBeforeCommand(SelectQueryExpression expression, IDbCommand command, SqlStatement statement)
        {
            if (events.OnBeforeCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before command events for select query.");
                events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)));
            }
            if (events.OnBeforeSelectCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before select command events for select query.");
                events.OnBeforeSelectCommand?.Invoke(new Lazy<BeforeSelectCommandPipelineEventContext>(() => new BeforeSelectCommandPipelineEventContext(expression, command, statement)));
            }
        }

        private void OnAfterCommand(SelectQueryExpression expression, IDbCommand command)
        {
            if (events.OnAfterSelectCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select command events for select query.");
                events.OnAfterSelectCommand?.Invoke(new Lazy<AfterSelectCommandPipelineEventContext>(() => new AfterSelectCommandPipelineEventContext(expression, command)));
            }
            if (events.OnAfterCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after command events for select query.");
                events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)));
            }
        }

        private void OnAfterComplete(SelectQueryExpression expression)
        {
            if (events.OnAfterSelectComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select complete events for select query.");
                events.OnAfterSelectComplete?.Invoke(new Lazy<AfterSelectCompletePipelineEventContext>(() => new AfterSelectCompletePipelineEventContext(expression)));
            }
            if (events.OnAfterComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after complete events for select query.");
                events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
            }
        }
        #endregion

        #region async
        private async Task OnBeforeStartAsync(SelectQueryExpression expression, CancellationToken ct)
        {
            if (events.OnBeforeStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before start events for select query.");
                await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            if (events.OnBeforeSelectStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before select start events for select query.");
                await events.OnBeforeSelectStart.InvokeAsync(new Lazy<BeforeSelectStartPipelineEventContext>(() => new BeforeSelectStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }

        private async Task OnAfterAssemblyAsync(SelectQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement, CancellationToken ct)
        {
            if (events.OnAfterSelectAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select assembly events for select query.");
                await events.OnAfterSelectAssembly.InvokeAsync(new Lazy<AfterSelectAssemblyPipelineEventContext>(() => new AfterSelectAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            if (events.OnAfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for select query.");
                await events.OnAfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }

        private async Task OnBeforeCommandAsync(SelectQueryExpression expression, IDbCommand command, SqlStatement statement, CancellationToken ct)
        {
            if (events.OnBeforeCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before command events for select query.");
                await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            if (events.OnBeforeSelectCommand is not null && !ct.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before select command events for select query.");
                await events.OnBeforeSelectCommand.InvokeAsync(new Lazy<BeforeSelectCommandPipelineEventContext>(() => new BeforeSelectCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }

        private async Task OnAfterCommandAsync(SelectQueryExpression expression, IDbCommand command, CancellationToken ct)
        {
            if (events.OnAfterSelectCommand is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select command events for select query.");
                await events.OnAfterSelectCommand.InvokeAsync(new Lazy<AfterSelectCommandPipelineEventContext>(() => new AfterSelectCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
            }
            if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after command events for select query.");
                await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
            }
        }

        private async Task OnAfterCompleteAsync(SelectQueryExpression expression, CancellationToken ct)
        {
            if (events.OnAfterSelectComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after select complete events for select query.");
                await events.OnAfterSelectComplete.InvokeAsync(new Lazy<AfterSelectCompletePipelineEventContext>(() => new AfterSelectCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            if (events.OnAfterComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after complete events for select query.");
                await events.OnAfterComplete.InvokeAsync(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}