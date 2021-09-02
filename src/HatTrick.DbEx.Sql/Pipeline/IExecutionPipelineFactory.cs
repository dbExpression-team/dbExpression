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

﻿using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface IExecutionPipelineFactory
    {
        PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; }
        PipelineEventActions<Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdateAssemblyPipelineExecutionContext>, BeforeUpdateAssemblyPipelineExecutionContext> BeforeUpdateAssembly { get; set; }
        PipelineEventActions<Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertAssemblyPipelineExecutionContext>, BeforeInsertAssemblyPipelineExecutionContext> BeforeInsertAssembly { get; set; }
        PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; }
        PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; }
        PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; }
        PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext> BeforeDelete { get; set; }
        PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext> AfterDelete { get; set; }
        PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext> BeforeUpdate { get; set; }
        PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext> AfterUpdate { get; set; }
        PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext> BeforeSelect { get; set; }
        PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext> AfterSelect { get; set; }
        PipelineEventActions<Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<BeforeStoredProcedurePipelineExecutionContext>, BeforeStoredProcedurePipelineExecutionContext> BeforeStoredProcedure { get; set; }
        PipelineEventActions<Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<AfterStoredProcedurePipelineExecutionContext>, AfterStoredProcedurePipelineExecutionContext> AfterStoredProcedure { get; set; }
        PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; }
        PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext> AfterExecution { get; set; }


        IInsertQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression)
            where T : class, IDbEntity;
        IUpdateQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, UpdateQueryExpression expression)
            where T : class, IDbEntity;
        IDeleteQueryExpressionExecutionPipeline<T> CreateExecutionPipeline<T>(RuntimeSqlDatabaseConfiguration database, DeleteQueryExpression expression)
            where T : class, IDbEntity;
        ISelectQueryExpressionExecutionPipeline CreateExecutionPipeline(RuntimeSqlDatabaseConfiguration database, SelectQueryExpression expression);
        IStoredProcedureQueryExpressionExecutionPipeline CreateExecutionPipeline(RuntimeSqlDatabaseConfiguration database, StoredProcedureQueryExpression expression);
    }
}
