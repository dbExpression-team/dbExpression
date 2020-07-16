using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class ExecutionPipelineFactory
    {
        #region internals
        private readonly DatabaseConfiguration configuration;
        #endregion

        #region interface
        public PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; } = new BeforeAssemblyPipelineEventActions();
        public PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; } = new AfterAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; } = new BeforeInsertPipelineEventActions();
        public PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; } = new AfterInsertPipelineEventActions();
        public PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; } = new BeforeExecutionPipelineEventActions();
        #endregion

        #region constructors
        public ExecutionPipelineFactory(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public AsyncExecutionPipeline CreateAsyncExecutionPipeline()
        {
            return new AsyncExecutionPipeline(
                configuration,
                new AsyncPipeline<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.AsyncActions),
                new AsyncPipeline<AfterAssemblyPipelineExecutionContext>(AfterAssembly.AsyncActions),
                new AsyncPipeline<BeforeInsertPipelineExecutionContext>(BeforeInsert.AsyncActions),
                new AsyncPipeline<AfterInsertPipelineExecutionContext>(AfterInsert.AsyncActions),
                new AsyncPipeline<BeforeExecutionPipelineExecutionContext>(BeforeExecution.AsyncActions)
           );
        }

        public SyncExecutionPipeline CreateSyncExecutionPipeline()
        {
            return new SyncExecutionPipeline(
                configuration,
                new SyncPipeline<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions),
                new SyncPipeline<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions),
                new SyncPipeline<BeforeInsertPipelineExecutionContext>(BeforeInsert.SyncActions),
                new SyncPipeline<AfterInsertPipelineExecutionContext>(AfterInsert.SyncActions),
                new SyncPipeline<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions)
            );
        }
        #endregion
    }
}
