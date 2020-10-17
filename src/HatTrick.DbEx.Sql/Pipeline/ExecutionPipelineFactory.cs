using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class ExecutionPipelineFactory : IExecutionPipelineFactory
    {
        #region interface
        public PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; } = new BeforeAssemblyPipelineEventActions();
        public PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; } = new AfterAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; } = new BeforeInsertPipelineEventActions();
        public PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; } = new AfterInsertPipelineEventActions();
        public PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext> BeforeDelete { get; set; } = new BeforeDeletePipelineEventActions();
        public PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext> AfterDelete { get; set; } = new AfterDeletePipelineEventActions();
        public PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext> BeforeUpdate { get; set; } = new BeforeUpdatePipelineEventActions();
        public PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext> AfterUpdate { get; set; } = new AfterUpdatePipelineEventActions();
        public PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext> BeforeSelect { get; set; } = new BeforeSelectPipelineEventActions();
        public PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext> AfterSelect { get; set; } = new AfterSelectPipelineEventActions();
        public PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; } = new BeforeExecutionPipelineEventActions();
        public PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext> AfterExecution { get; set; } = new AfterExecutionPipelineEventActions();
        #endregion

        #region methods
        public virtual IInsertQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression)
            where T : class, IDbEntity
        {
            return new InsertQueryExpressionExecutionPipeline<T>(
                database,
                new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions, BeforeAssembly.AsyncActions),
                new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions, AfterAssembly.AsyncActions),
                new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions, BeforeExecution.AsyncActions),
                new PipelineEventHook<AfterExecutionPipelineExecutionContext>(AfterExecution.SyncActions, AfterExecution.AsyncActions),
                new PipelineEventHook<BeforeInsertPipelineExecutionContext>(BeforeInsert.SyncActions, BeforeInsert.AsyncActions),
                new PipelineEventHook<AfterInsertPipelineExecutionContext>(AfterInsert.SyncActions, AfterInsert.AsyncActions)
            );
        }

        public virtual IUpdateQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, UpdateQueryExpression expression)
            where T : class, IDbEntity
        {
            return new UpdateQueryExpressionExecutionPipeline<T>(
                database,
                new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions, BeforeAssembly.AsyncActions),
                new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions, AfterAssembly.AsyncActions),
                new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions, BeforeExecution.AsyncActions),
                new PipelineEventHook<AfterExecutionPipelineExecutionContext>(AfterExecution.SyncActions, AfterExecution.AsyncActions),
                new PipelineEventHook<BeforeUpdatePipelineExecutionContext>(BeforeUpdate.SyncActions, BeforeUpdate.AsyncActions),
                new PipelineEventHook<AfterUpdatePipelineExecutionContext>(AfterUpdate.SyncActions, AfterUpdate.AsyncActions)
            );
        }

        public virtual IDeleteQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, DeleteQueryExpression expression)
            where T : class, IDbEntity
        {
            return new DeleteQueryExpressionExecutionPipeline<T>(
                database,
                new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions, BeforeAssembly.AsyncActions),
                new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions, AfterAssembly.AsyncActions),
                new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions, BeforeExecution.AsyncActions),
                new PipelineEventHook<AfterExecutionPipelineExecutionContext>(AfterExecution.SyncActions, AfterExecution.AsyncActions),
                new PipelineEventHook<BeforeDeletePipelineExecutionContext>(BeforeDelete.SyncActions, BeforeDelete.AsyncActions),
                new PipelineEventHook<AfterDeletePipelineExecutionContext>(AfterDelete.SyncActions, AfterDelete.AsyncActions)
            );
        }

        public virtual ISelectQueryExpressionExecutionPipeline CreateExecutionPipeline(RuntimeSqlDatabaseConfiguration database, SelectQueryExpression expression)
        {
            return new SelectQueryExpressionExecutionPipeline(
                database,
                new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions, BeforeAssembly.AsyncActions),
                new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions, AfterAssembly.AsyncActions),
                new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions, BeforeExecution.AsyncActions),
                new PipelineEventHook<AfterExecutionPipelineExecutionContext>(AfterExecution.SyncActions, AfterExecution.AsyncActions),
                new PipelineEventHook<BeforeSelectPipelineExecutionContext>(BeforeSelect.SyncActions, BeforeSelect.AsyncActions),
                new PipelineEventHook<AfterSelectPipelineExecutionContext>(AfterSelect.SyncActions, AfterSelect.AsyncActions)
            );
        }
        #endregion
    }
}
