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

using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface ISelectSetQueryExpressionExecutionPipeline
    {
        #region entity list
        IList<T> ExecuteSelectEntityList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
            where T : class, IDbEntity, new();

        IList<T> ExecuteSelectEntityList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map)
            where T : class, IDbEntity, new();

        void ExecuteSelectEntityList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            where T : class, IDbEntity;

        IList<T> ExecuteSelectEntityList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
            where T : class, IDbEntity;

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
            where T : class, IDbEntity;

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new();
        #endregion

        #region value list
        IList<T> ExecuteSelectValueList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand);
        void ExecuteSelectValueList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<T?> read);

        Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteSelectValueListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<T?> read, CancellationToken ct);
        Task ExecuteSelectValueListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<T?, Task> read, CancellationToken ct);
        #endregion

        #region dynamic list
        IList<dynamic> ExecuteSelectDynamicList(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand);
        void ExecuteSelectDynamicList(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read);

        Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct);
        #endregion

        #region object list
        IList<T> ExecuteSelectObjectList<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map);

        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, T?> map, CancellationToken ct);
        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectSetQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task<T?>> map, CancellationToken ct);
        #endregion
    }
}
