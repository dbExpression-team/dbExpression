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
    public class BatchBuilder : IBatchContinuationBuilder
    {
        private readonly ISqlConnectionFactory connectionFactory;
        private readonly List<INonQueryTerminationExpressionBuilder> batch = new();

        public BatchBuilder(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        IBatchContinuationBuilder IBatchBuilder.Add(params INonQueryTerminationExpressionBuilder[] expressions)
        {
            batch.AddRange(expressions);
            return this;
        }
        IBatchContinuationBuilder IBatchBuilder.Add(IList<INonQueryTerminationExpressionBuilder> expressions)
        {
            batch.AddRange(expressions);
            return this;
        }
        IBatchContinuationBuilder IBatchBuilder.Add(IEnumerable<INonQueryTerminationExpressionBuilder> expressions)
        {
            batch.AddRange(expressions);
            return this;
        }

        IDictionary<int, object?> IBatchTerminationBuilder.Execute()
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
                    if (exp is DeleteEntitiesTermination delete)
                    {
                        results.Add(i, delete.Execute(connection));
                    }
                    else if (exp is UpdateEntitiesTermination update)
                    {
                        results.Add(i, update.Execute(connection));
                    }
                    else if (exp is InsertEntitiesTermination insert)
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

        async Task<IDictionary<int, object?>> IBatchTerminationBuilder.ExecuteAsync()
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
                        if (exp is DeleteEntitiesTermination delete)
                        {
                            results.Add(i, await delete.ExecuteAsync(connection).ConfigureAwait(false));
                        }
                        else if (exp is UpdateEntitiesTermination update)
                        {
                            results.Add(i, await update.ExecuteAsync(connection).ConfigureAwait(false));
                        }
                        else if (exp is InsertEntitiesTermination insert)
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
