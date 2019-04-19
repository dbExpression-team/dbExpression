using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class ExecutionPipelineFactory
    {
        #region internals
        private DbExpressionConfiguration _config;
        private DatabaseConfiguration _database;
        #endregion

        #region interface
        public PipelinePair<Func<BeforeAssemblyContext, CancellationToken, Task>, Action<BeforeAssemblyContext>> BeforeAssembly { get; set; } = new BeforeAssemblyPipeline();
        public PipelinePair<Func<AfterAssemblyContext, CancellationToken, Task>, Action<AfterAssemblyContext>> AfterAssembly { get; set; } = new AfterAssemblyPipeline();
        public PipelinePair<Func<BeforeInsertContext, CancellationToken, Task>, Action<BeforeInsertContext>> BeforeInsert { get; set; } = new BeforeInsertPipeline();
        public PipelinePair<Func<AfterInsertContext, CancellationToken, Task>, Action<AfterInsertContext>> AfterInsert { get; set; } = new AfterInsertPipeline();
        #endregion

        #region constructors
        public ExecutionPipelineFactory(
            DbExpressionConfiguration config,
            DatabaseConfiguration database
        )
        {
            _config = config;
            _database = database;
        }
        #endregion

        #region methods
        public AsyncExecutionPipeline CreateAsyncExecutionPipeline()
        {
            return new AsyncExecutionPipeline(
                _config,
                _database,
                new AsyncPipeline<BeforeAssemblyContext>(BeforeAssembly.AsyncActions),
                new AsyncPipeline<AfterAssemblyContext>(AfterAssembly.AsyncActions),
                new AsyncPipeline<BeforeInsertContext>(BeforeInsert.AsyncActions),
                new AsyncPipeline<AfterInsertContext>(AfterInsert.AsyncActions)
            );
        }

        public SyncExecutionPipeline CreateSyncExecutionPipeline()
        {
            return new SyncExecutionPipeline(
                _config,
                _database,
                new SyncPipeline<BeforeAssemblyContext>(BeforeAssembly.SyncActions),
                new SyncPipeline<AfterAssemblyContext>(AfterAssembly.SyncActions),
                new SyncPipeline<BeforeInsertContext>(BeforeInsert.SyncActions),
                new SyncPipeline<AfterInsertContext>(AfterInsert.SyncActions)
            );
        }
        #endregion
    }
}
