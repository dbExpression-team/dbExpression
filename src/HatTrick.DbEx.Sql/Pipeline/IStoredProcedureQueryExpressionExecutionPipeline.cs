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
    public interface IStoredProcedureQueryExpressionExecutionPipeline : IQueryExpressionExecutionPipeline
    {
        void Execute(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        void Execute(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task ExecuteAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        Task ExecuteAsync(StoredProcedureQueryExpression expression, Action<ISqlFieldReader> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);

        #region value
        T? ExecuteSelectValue<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<T?> ExecuteSelectValueAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region value list
        IList<T> ExecuteSelectValueList<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<IList<T>> ExecuteSelectValueListAsync<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        IAsyncEnumerable<T> ExecuteSelectValueListAsyncEnumerable<T>(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region object
        T? ExecuteSelectObject<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<T?> ExecuteSelectObjectAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region object list
        IList<T> ExecuteSelectObjectList<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<IList<T>> ExecuteSelectObjectListAsync<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        IAsyncEnumerable<T> ExecuteSelectObjectListAsyncEnumerable<T>(StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region dynamic
        dynamic? ExecuteSelectDynamic(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<dynamic?> ExecuteSelectDynamicAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion

        #region dynamic list
        IList<dynamic> ExecuteSelectDynamicList(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand);
        Task<IList<dynamic>> ExecuteSelectDynamicListAsync(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        IAsyncEnumerable<dynamic> ExecuteSelectDynamicListAsyncEnumerable(StoredProcedureQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct);
        #endregion
    }
}
