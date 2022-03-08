using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class BatchBuilder : IBatchContinuationBuilder
    {
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private readonly List<INonQueryTerminationExpressionBuilder> batch = new();

        public BatchBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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

            using var connection = new SqlConnector(configuration.ConnectionStringFactory, configuration.ConnectionFactory);
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

            using (var connection = new SqlConnector(configuration.ConnectionStringFactory, configuration.ConnectionFactory))
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
