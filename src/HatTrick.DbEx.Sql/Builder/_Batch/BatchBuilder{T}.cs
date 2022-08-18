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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class BatchBuilder<TDatabase> : IBatchContinuationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        private readonly ISqlConnectionFactory connectionFactory;
        private readonly List<INonQueryTerminationExpressionBuilder<TDatabase>> batch = new();

        public BatchBuilder(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        IBatchContinuationBuilder<TDatabase> IBatchBuilder<TDatabase>.Add(params INonQueryTerminationExpressionBuilder<TDatabase>[] expressions)
        {
            batch.AddRange(expressions);
            return this;
        }
        IBatchContinuationBuilder<TDatabase> IBatchBuilder<TDatabase>.Add(IList<INonQueryTerminationExpressionBuilder<TDatabase>> expressions)
        {
            batch.AddRange(expressions);
            return this;
        }
        IBatchContinuationBuilder<TDatabase> IBatchBuilder<TDatabase>.Add(IEnumerable<INonQueryTerminationExpressionBuilder<TDatabase>> expressions)
        {
            batch.AddRange(expressions);
            return this;
        }

        IDictionary<int, object?> IBatchTerminationBuilder<TDatabase>.Execute()
        {
            var results = new Dictionary<int, object?>();

            if (batch.Count == 0)
                return results;

            using var connection = new SqlConnector(connectionFactory);
            try
            {
                connection.EnsureOpen();
                connection.BeginTransaction();
                for (var i = 0; i < batch.Count; i++)
                {
                    var exp = batch[i];
                    if (exp is DeleteEntitiesTermination<TDatabase> delete)
                    {
                        results.Add(i, delete.Execute(connection));
                    }
                    else if (exp is UpdateEntitiesTermination<TDatabase> update)
                    {
                        results.Add(i, update.Execute(connection));
                    }
                    else if (exp is InsertEntitiesTermination<TDatabase> insert)
                    {
                        insert.Execute(connection);
                        results.Add(i, default);
                    }
                }
                connection.CommitTransaction();
            }
            catch (Exception)
            {
                connection.RollbackTransaction();
                throw;
            }

            return results;
        }

        async Task<IDictionary<int, object?>> IBatchTerminationBuilder<TDatabase>.ExecuteAsync()
        {
            var results = new Dictionary<int, object?>();

            if (batch.Count == 0)
                return results;

            using (var connection = new SqlConnector(connectionFactory))
            {
                try
                {
                    connection.EnsureOpen();
                    connection.BeginTransaction();
                    for (var i = 0; i < batch.Count; i++)
                    {
                        var exp = batch[i];
                        if (exp is DeleteEntitiesTermination<TDatabase> delete)
                        {
                            results.Add(i, await delete.ExecuteAsync(connection).ConfigureAwait(false));
                        }
                        else if (exp is UpdateEntitiesTermination<TDatabase> update)
                        {
                            results.Add(i, await update.ExecuteAsync(connection).ConfigureAwait(false));
                        }
                        else if (exp is InsertEntitiesTermination<TDatabase> insert)
                        {
                            await insert.ExecuteAsync(connection).ConfigureAwait(false);
                            results.Add(i, default);
                        }
                    }
                    connection.CommitTransaction();
                }
                catch (Exception)
                {
                    connection.RollbackTransaction();
                    throw;
                }
            }
            return results;
        }

    }
}
