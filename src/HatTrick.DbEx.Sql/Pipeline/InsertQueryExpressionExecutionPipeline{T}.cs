using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertQueryExpressionExecutionPipeline<T> : IInsertQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeInsertPipelineExecutionContext> beforeInsert;
        private readonly PipelineEventHook<AfterInsertPipelineExecutionContext> afterInsert;
        #endregion

        #region constructors
        public InsertQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeInsertPipelineExecutionContext> beforeInsert,
            PipelineEventHook<AfterInsertPipelineExecutionContext> afterInsert
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeInsert = beforeInsert;
            this.afterInsert = afterInsert;
        }
        #endregion

        #region methods
        public virtual void ExecuteInsert(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)));

            if (beforeInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    beforeInsert?.Invoke(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(database, expression, insert, appender, parameterBuilder)));
            }

            var fields = new List<FieldExpression> { null }.Concat(expression.Outputs).ToList();

            var reader = database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteQuery(
                statement,
                connection,
                new SqlStatementValueConverterResolver(fields, database.ValueConverterFactory),
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statement, cmd)));
                    configureCommand?.Invoke(cmd);
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)))
            );

            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);

            ISqlRow row;
            while ((row = reader.ReadRow()) is object)
            {
                var index = 0;
                try
                {
                    index = row.ReadField().GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(entity as T, row);
            }

            if (afterInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    afterInsert?.Invoke(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(database, expression, insert, statement)));
            }
        }

        public virtual async Task ExecuteInsertAsync(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
            }

            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)), ct).ConfigureAwait(false);
            }

            if (beforeInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    await beforeInsert.InvokeAsync(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(database, expression, insert, appender, parameterBuilder)), ct).ConfigureAwait(false);
            }

            var fields = new List<FieldExpression> { null }.Concat(expression.Outputs).ToList();

            var reader = await database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteQueryAsync(
                statement,
                connection,
                new SqlStatementValueConverterResolver(fields, database.ValueConverterFactory),
                async cmd => {
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statementBuilder.CreateSqlStatement(), cmd)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd => {
                    if (afterExecution is object)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);

            ISqlRow row;
            while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
            {
                var index = 0;
                try
                {
                    index = row.ReadField().GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(entity as T, row);
            }

            if (afterInsert is object)
            {
                foreach (var insert in expression.Inserts.Values)
                    await afterInsert.InvokeAsync(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(database, expression, insert, statement)), ct).ConfigureAwait(false);
            }
        }
        #endregion
    }
}
