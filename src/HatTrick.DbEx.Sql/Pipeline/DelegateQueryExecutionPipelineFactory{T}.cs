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

using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class DelegateQueryExecutionPipelineFactory<TDatabase> : IQueryExecutionPipelineFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        private readonly Func<Type,object> factory;

        public DelegateQueryExecutionPipelineFactory(Func<Type, IQueryExecutionPipeline<TDatabase>> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IInsertQueryExecutionPipeline<TDatabase> CreateInsertQueryExecutionPipeline()
            => (factory(typeof(IInsertQueryExecutionPipeline<TDatabase>))! as IInsertQueryExecutionPipeline<TDatabase>)!;

        public IUpdateQueryExecutionPipeline<TDatabase> CreateUpdateQueryExecutionPipeline()
            => (factory(typeof(IUpdateQueryExecutionPipeline<TDatabase>))! as IUpdateQueryExecutionPipeline<TDatabase>)!;

        public IDeleteQueryExecutionPipeline<TDatabase> CreateDeleteQueryExecutionPipeline()
            => (factory(typeof(IDeleteQueryExecutionPipeline<TDatabase>))! as IDeleteQueryExecutionPipeline<TDatabase>)!;

        public ISelectQueryExecutionPipeline<TDatabase> CreateSelectQueryExecutionPipeline()
            => (factory(typeof(ISelectQueryExecutionPipeline<TDatabase>))! as ISelectQueryExecutionPipeline<TDatabase>)!;

        public ISelectSetQueryExecutionPipeline<TDatabase> CreateSelectSetQueryExecutionPipeline()
            => (factory(typeof(ISelectSetQueryExecutionPipeline<TDatabase>))! as ISelectSetQueryExecutionPipeline<TDatabase>)!;

        public IStoredProcedureExecutionPipeline<TDatabase> CreateStoredProcedureExecutionPipeline()
            => (factory(typeof(IStoredProcedureExecutionPipeline<TDatabase>))! as IStoredProcedureExecutionPipeline<TDatabase>)!;
    }
}
