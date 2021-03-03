using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ExecutionPipelineEventConfigurationBuilder : IExecutionPipelineEventConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public ExecutionPipelineEventConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        #region assembly
        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region insert
        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region update
        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region delete
        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region select
        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion


        #region execution
        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion
        #endregion
    }
}
