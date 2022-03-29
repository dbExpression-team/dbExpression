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

﻿using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct);
        ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution);
        Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct);
        T? ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution);
        Task<T?> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct);
    }
}
