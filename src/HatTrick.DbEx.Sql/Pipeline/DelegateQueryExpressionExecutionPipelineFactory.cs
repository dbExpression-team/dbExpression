﻿#region license
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

using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class DelegateQueryExpressionExecutionPipelineFactory : IQueryExpressionExecutionPipelineFactory
    {
        private readonly Func<Type,object> factory;

        public DelegateQueryExpressionExecutionPipelineFactory(Func<Type, IQueryExpressionExecutionPipeline> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IInsertQueryExpressionExecutionPipeline CreateInsertQueryExecutionPipeline()
            => (factory(typeof(IInsertQueryExpressionExecutionPipeline))! as IInsertQueryExpressionExecutionPipeline)!;

        public IUpdateQueryExpressionExecutionPipeline CreateUpdateQueryExecutionPipeline()
            => (factory(typeof(IUpdateQueryExpressionExecutionPipeline))! as IUpdateQueryExpressionExecutionPipeline)!;

        public IDeleteQueryExpressionExecutionPipeline CreateDeleteQueryExecutionPipeline()
            => (factory(typeof(IDeleteQueryExpressionExecutionPipeline))! as IDeleteQueryExpressionExecutionPipeline)!;

        public ISelectQueryExpressionExecutionPipeline CreateSelectQueryExecutionPipeline()
            => (factory(typeof(ISelectQueryExpressionExecutionPipeline))! as ISelectQueryExpressionExecutionPipeline)!;

        public IStoredProcedureExpressionExecutionPipeline CreateStoredProcedureExecutionPipeline()
            => (factory(typeof(IStoredProcedureExpressionExecutionPipeline))! as IStoredProcedureExpressionExecutionPipeline)!;
    }
}
