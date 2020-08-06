using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface IExecutionPipelineFactory
    {
        PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; }
        PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; }
        PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; }
        PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; }
        PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext> BeforeDelete { get; set; }
        PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext> AfterDelete { get; set; }
        PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext> BeforeUpdate { get; set; }
        PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext> AfterUpdate { get; set; }
        PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext> BeforeSelect { get; set; }
        PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext> AfterSelect { get; set; }
        PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; }
        PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext> AfterExecution { get; set; }


        IInsertQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(DatabaseConfiguration database, InsertQueryExpression expression)
            where T : class, IDbEntity;
        IUpdateQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(DatabaseConfiguration database, UpdateQueryExpression expression)
            where T : class, IDbEntity;
        IDeleteQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(DatabaseConfiguration database, DeleteQueryExpression expression)
            where T : class, IDbEntity;
        ISelectQueryExpressionExecutionPipeline CreateExecutionPipeline(DatabaseConfiguration database, SelectQueryExpression expression);
    }
}
