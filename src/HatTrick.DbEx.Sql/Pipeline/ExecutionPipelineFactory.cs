using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class ExecutionPipelineFactory
    {
        #region internals
        private readonly DatabaseConfiguration Database;
        #endregion

        #region interface
        public PipelineEventActions<Func<BeforeAssemblyContext, CancellationToken, Task>, Action<BeforeAssemblyContext>> BeforeAssembly { get; set; } = new BeforeAssemblyPipelineEvent();
        public PipelineEventActions<Func<AfterAssemblyContext, CancellationToken, Task>, Action<AfterAssemblyContext>> AfterAssembly { get; set; } = new AfterAssemblyPipelineEvent();
        public PipelineEventActions<Func<BeforeInsertContext, CancellationToken, Task>, Action<BeforeInsertContext>> BeforeInsert { get; set; } = new BeforeInsertPipelineEvent();
        public PipelineEventActions<Func<AfterInsertContext, CancellationToken, Task>, Action<AfterInsertContext>> AfterInsert { get; set; } = new AfterInsertPipelineEvent();
        #endregion

        #region constructors
        public ExecutionPipelineFactory(
            DatabaseConfiguration database
        )
        {
            Database = database;
        }
        #endregion

        #region methods
        public AsyncExecutionPipeline CreateAsyncExecutionPipeline()
        {
            return new AsyncExecutionPipeline(
                Database,
                new AsyncPipeline<BeforeAssemblyContext>(BeforeAssembly.AsyncActions),
                new AsyncPipeline<AfterAssemblyContext>(AfterAssembly.AsyncActions),
                new AsyncPipeline<BeforeInsertContext>(BeforeInsert.AsyncActions),
                new AsyncPipeline<AfterInsertContext>(AfterInsert.AsyncActions)
            );
        }

        public SyncExecutionPipeline CreateSyncExecutionPipeline()
        {
            return new SyncExecutionPipeline(
                Database,
                new SyncPipeline<BeforeAssemblyContext>(BeforeAssembly.SyncActions),
                new SyncPipeline<AfterAssemblyContext>(AfterAssembly.SyncActions),
                new SyncPipeline<BeforeInsertContext>(BeforeInsert.SyncActions),
                new SyncPipeline<AfterInsertContext>(AfterInsert.SyncActions)
            );
        }
        #endregion
    }
}
