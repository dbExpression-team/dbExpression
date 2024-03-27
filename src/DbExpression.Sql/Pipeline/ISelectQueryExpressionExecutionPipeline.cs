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

﻿using DbExpression.Sql.Connection;
using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
{
    public interface ISelectQueryExpressionExecutionPipeline : IQueryExpressionExecutionPipeline
    {
        #region entity
        TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity, new();

        TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity?> map)
            where TEntity : class, IDbEntity;

        void ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity;

        TEntity? ExecuteSelectEntity<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new();

        Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        Task ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
            where TEntity : class, IDbEntity;

        Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity?> map, CancellationToken ct)
            where TEntity : class, IDbEntity;

        Task ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
            where TEntity : class, IDbEntity;

        Task<TEntity?> ExecuteSelectEntityAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();
        #endregion

        #region entity list
        IList<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity, new();

        IList<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new();

        void ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity;

        IList<TEntity> ExecuteSelectEntityList<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new();

        Task ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
            where TEntity : class, IDbEntity;

        Task ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
            where TEntity : class, IDbEntity;
        
        Task<IList<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        Task<IList<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        Task<IList<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        Task<IList<TEntity>> ExecuteSelectEntityListAsync<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();

        IAsyncEnumerable<TEntity> ExecuteSelectEntityListAsyncEnumerable<TEntity>(SelectQueryExpression expression, Table<TEntity> table, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken ct)
            where TEntity : class, IDbEntity, new();
        #endregion

        #region value
        T? ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);

        Task<T?> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region value list
        IList<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        void ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<T?> read);
        Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<T?> read, CancellationToken ct);
        Task ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<T?, Task> read, CancellationToken ct);
        IAsyncEnumerable<T> ExecuteSelectValueListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region dynamic
        dynamic? ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        void ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read);

        Task<dynamic?> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct);
        Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct);
        #endregion

        #region dynamic list
        IList<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        void ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read);

        Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct);
        IAsyncEnumerable<dynamic> ExecuteSelectDynamicListAsyncEnumerable(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region object
        T? ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map);

        Task<T?> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct);
        Task<T?> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct);
        #endregion

        #region object list
        IList<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map);

        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct);
        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct);
        IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct);
        IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(SelectQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct);
        #endregion
    }
}
