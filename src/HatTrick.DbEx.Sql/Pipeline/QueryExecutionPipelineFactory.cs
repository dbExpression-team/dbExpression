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
    public class QueryExecutionPipelineFactory : IQueryExecutionPipelineFactory
    {
        #region internals
        private PipelineEventHook<BeforeAssemblyPipelineExecutionContext>? _beforeAssemblyPipelineEventHook;
        private PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext>? _beforeUpdateAssemblyPipelineEventHook;
        private PipelineEventHook<BeforeInsertAssemblyPipelineExecutionContext>? _beforeInsertAssemblyPipelineEventHook;
        private PipelineEventHook<AfterAssemblyPipelineExecutionContext>? _afterAssemblyPipelineEventHook;
        private PipelineEventHook<BeforeExecutionPipelineExecutionContext>? _beforeExecutionPipelineEventHook;
        private PipelineEventHook<AfterExecutionPipelineExecutionContext>? _afterExecutionPipelineEventHook;
        private PipelineEventHook<BeforeInsertPipelineExecutionContext>? _beforeInsertPipelineEventHook;
        private PipelineEventHook<AfterInsertPipelineExecutionContext>? _afterInsertPipelineEventHook;
        private PipelineEventHook<BeforeDeletePipelineExecutionContext>? _beforeDeletePipelineEventHook;
        private PipelineEventHook<AfterDeletePipelineExecutionContext>? _afterDeletePipelineEventHook;
        private PipelineEventHook<BeforeUpdatePipelineExecutionContext>? _beforeUpdatePipelineEventHook;
        private PipelineEventHook<AfterUpdatePipelineExecutionContext>? _afterUpdatePipelineEventHook;
        private PipelineEventHook<BeforeSelectPipelineExecutionContext>? _beforeSelectPipelineEventHook;
        private PipelineEventHook<AfterSelectPipelineExecutionContext>? _afterSelectPipelineEventHook;
        private PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext>? _beforeStoredProcedurePipelineEventHook;
        private PipelineEventHook<AfterStoredProcedurePipelineExecutionContext>? afterStoredProcedurePipelineEventHook;

        private PipelineEventHook<BeforeAssemblyPipelineExecutionContext> BeforeAssemblyPipelineEventHook => _beforeAssemblyPipelineEventHook ??= new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(BeforeAssembly.SyncActions, BeforeAssembly.AsyncActions);
        private PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext> BeforeUpdateAssemblyPipelineEventHook => _beforeUpdateAssemblyPipelineEventHook ??= new PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext>(BeforeUpdateAssembly.SyncActions, BeforeUpdateAssembly.AsyncActions);
        private PipelineEventHook<BeforeInsertAssemblyPipelineExecutionContext> BeforeInsertAssemblyPipelineEventHook => _beforeInsertAssemblyPipelineEventHook ??= new PipelineEventHook<BeforeInsertAssemblyPipelineExecutionContext>(BeforeInsertAssembly.SyncActions, BeforeInsertAssembly.AsyncActions);
        private PipelineEventHook<AfterAssemblyPipelineExecutionContext> AfterAssemblyPipelineEventHook => _afterAssemblyPipelineEventHook ??= new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(AfterAssembly.SyncActions, AfterAssembly.AsyncActions);
        private PipelineEventHook<BeforeExecutionPipelineExecutionContext> BeforeExecutionPipelineEventHook => _beforeExecutionPipelineEventHook ??= new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(BeforeExecution.SyncActions, BeforeExecution.AsyncActions);
        private PipelineEventHook<AfterExecutionPipelineExecutionContext> AfterExecutionPipelineEventHook => _afterExecutionPipelineEventHook ??= new PipelineEventHook<AfterExecutionPipelineExecutionContext>(AfterExecution.SyncActions, AfterExecution.AsyncActions);
        private PipelineEventHook<BeforeInsertPipelineExecutionContext> BeforeInsertPipelineEventHook => _beforeInsertPipelineEventHook ??= new PipelineEventHook<BeforeInsertPipelineExecutionContext>(BeforeInsert.SyncActions, BeforeInsert.AsyncActions);
        private PipelineEventHook<AfterInsertPipelineExecutionContext> AfterInsertPipelineEventHook => _afterInsertPipelineEventHook ??= new PipelineEventHook<AfterInsertPipelineExecutionContext>(AfterInsert.SyncActions, AfterInsert.AsyncActions);
        private PipelineEventHook<BeforeDeletePipelineExecutionContext> BeforeDeletePipelineEventHook => _beforeDeletePipelineEventHook ??= new PipelineEventHook<BeforeDeletePipelineExecutionContext>(BeforeDelete.SyncActions, BeforeDelete.AsyncActions);
        private PipelineEventHook<AfterDeletePipelineExecutionContext> AfterDeletePipelineEventHook => _afterDeletePipelineEventHook ??= new PipelineEventHook<AfterDeletePipelineExecutionContext>(AfterDelete.SyncActions, AfterDelete.AsyncActions);
        private PipelineEventHook<BeforeUpdatePipelineExecutionContext> BeforeUpdatePipelineEventHook => _beforeUpdatePipelineEventHook ??= new PipelineEventHook<BeforeUpdatePipelineExecutionContext>(BeforeUpdate.SyncActions, BeforeUpdate.AsyncActions);
        private PipelineEventHook<AfterUpdatePipelineExecutionContext> AfterUpdatePipelineEventHook => _afterUpdatePipelineEventHook ??= new PipelineEventHook<AfterUpdatePipelineExecutionContext>(AfterUpdate.SyncActions, AfterUpdate.AsyncActions);
        private PipelineEventHook<BeforeSelectPipelineExecutionContext> BeforeSelectPipelineEventHook => _beforeSelectPipelineEventHook ??= new PipelineEventHook<BeforeSelectPipelineExecutionContext>(BeforeSelect.SyncActions, BeforeSelect.AsyncActions);
        private PipelineEventHook<AfterSelectPipelineExecutionContext> AfterSelectPipelineEventHook => _afterSelectPipelineEventHook ??= new PipelineEventHook<AfterSelectPipelineExecutionContext>(AfterSelect.SyncActions, AfterSelect.AsyncActions);
        private PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext> BeforeStoredProcedurePipelineEventHook => _beforeStoredProcedurePipelineEventHook ??= new PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext>(BeforeStoredProcedure.SyncActions, BeforeStoredProcedure.AsyncActions);
        private PipelineEventHook<AfterStoredProcedurePipelineExecutionContext> AfterStoredProcedurePipelineEventHook => afterStoredProcedurePipelineEventHook ??= new PipelineEventHook<AfterStoredProcedurePipelineExecutionContext>(AfterStoredProcedure.SyncActions, AfterStoredProcedure.AsyncActions);
        #endregion

        #region interface
        public PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; } = new BeforeAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdateAssemblyPipelineExecutionContext>, BeforeUpdateAssemblyPipelineExecutionContext> BeforeUpdateAssembly { get; set; } = new BeforeUpdateAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertAssemblyPipelineExecutionContext>, BeforeInsertAssemblyPipelineExecutionContext> BeforeInsertAssembly { get; set; } = new BeforeInsertAssemblyPipelineEventActions();
        public PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; } = new AfterAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; } = new BeforeInsertPipelineEventActions();
        public PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; } = new AfterInsertPipelineEventActions();
        public PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext> BeforeDelete { get; set; } = new BeforeDeletePipelineEventActions();
        public PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext> AfterDelete { get; set; } = new AfterDeletePipelineEventActions();
        public PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext> BeforeUpdate { get; set; } = new BeforeUpdatePipelineEventActions();
        public PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext> AfterUpdate { get; set; } = new AfterUpdatePipelineEventActions();
        public PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext> BeforeSelect { get; set; } = new BeforeSelectPipelineEventActions();
        public PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext> AfterSelect { get; set; } = new AfterSelectPipelineEventActions();
        public PipelineEventActions<Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<BeforeStoredProcedurePipelineExecutionContext>, BeforeStoredProcedurePipelineExecutionContext> BeforeStoredProcedure { get; set; } = new BeforeStoredProcedurePipelineEventActions();
        public PipelineEventActions<Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<AfterStoredProcedurePipelineExecutionContext>, AfterStoredProcedurePipelineExecutionContext> AfterStoredProcedure { get; set; } = new AfterStoredProcedurePipelineEventActions();
        public PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; } = new BeforeExecutionPipelineEventActions();
        public PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext> AfterExecution { get; set; } = new AfterExecutionPipelineEventActions();
        #endregion

        #region methods
        public virtual IInsertQueryExpressionExecutionPipeline CreateQueryExecutionPipeline<T>(SqlDatabaseRuntimeConfiguration database, InsertQueryExpression expression)
            where T : class, IDbEntity
        {
            return new InsertQueryExpressionExecutionPipeline<T>(
                database,
                BeforeAssemblyPipelineEventHook,
                BeforeInsertAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeInsertPipelineEventHook,
                AfterInsertPipelineEventHook
            );
        }

        public virtual IUpdateQueryExpressionExecutionPipeline CreateQueryExecutionPipeline(SqlDatabaseRuntimeConfiguration database, UpdateQueryExpression expression)
        {
            return new UpdateQueryExpressionExecutionPipeline(
                database,
                BeforeAssemblyPipelineEventHook,
                BeforeUpdateAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeUpdatePipelineEventHook,
                AfterUpdatePipelineEventHook
            );
        }

        public virtual IDeleteQueryExpressionExecutionPipeline CreateQueryExecutionPipeline(SqlDatabaseRuntimeConfiguration database, DeleteQueryExpression expression)
        {
            return new DeleteQueryExpressionExecutionPipeline(
                database,
                BeforeAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeDeletePipelineEventHook,
                AfterDeletePipelineEventHook
            );
        }

        public virtual ISelectQueryExpressionExecutionPipeline CreateQueryExecutionPipeline(SqlDatabaseRuntimeConfiguration database, SelectQueryExpression expression)
        {
            return new SelectQueryExpressionExecutionPipeline(
                database,
                BeforeAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeSelectPipelineEventHook,
                AfterSelectPipelineEventHook
            );
        }

        public virtual ISelectSetQueryExpressionExecutionPipeline CreateQueryExecutionPipeline(SqlDatabaseRuntimeConfiguration database, SelectSetQueryExpression expression)
        {
            return new SelectQueryExpressionExecutionPipeline(
                database,
                BeforeAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeSelectPipelineEventHook,
                AfterSelectPipelineEventHook
            );
        }

        public IStoredProcedureQueryExpressionExecutionPipeline CreateQueryExecutionPipeline(SqlDatabaseRuntimeConfiguration database, StoredProcedureQueryExpression expression)
        {
            return new StoredProcedureQueryExpressionExecutionPipeline(
                database,
                BeforeAssemblyPipelineEventHook,
                AfterAssemblyPipelineEventHook,
                BeforeExecutionPipelineEventHook,
                AfterExecutionPipelineEventHook,
                BeforeStoredProcedurePipelineEventHook,
                AfterStoredProcedurePipelineEventHook
            );
        }
        #endregion
    }
}
