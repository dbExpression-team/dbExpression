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
    public class DelegateQueryExecutionPipelineFactory : IQueryExecutionPipelineFactory
    {
        private readonly Func<Type,object> factory;

        public DelegateQueryExecutionPipelineFactory(Func<Type, IQueryExecutionPipeline> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IInsertQueryExecutionPipeline CreateInsertQueryExecutionPipeline()
            => (factory(typeof(IInsertQueryExecutionPipeline))! as IInsertQueryExecutionPipeline)!;

        public IUpdateQueryExecutionPipeline CreateUpdateQueryExecutionPipeline()
            => (factory(typeof(IUpdateQueryExecutionPipeline))! as IUpdateQueryExecutionPipeline)!;

        public IDeleteQueryExecutionPipeline CreateDeleteQueryExecutionPipeline()
            => (factory(typeof(IDeleteQueryExecutionPipeline))! as IDeleteQueryExecutionPipeline)!;

        public ISelectQueryExecutionPipeline CreateSelectQueryExecutionPipeline()
            => (factory(typeof(ISelectQueryExecutionPipeline))! as ISelectQueryExecutionPipeline)!;

        public ISelectSetQueryExecutionPipeline CreateSelectSetQueryExecutionPipeline()
            => (factory(typeof(ISelectSetQueryExecutionPipeline))! as ISelectSetQueryExecutionPipeline)!;

        public IStoredProcedureExecutionPipeline CreateStoredProcedureExecutionPipeline()
            => (factory(typeof(IStoredProcedureExecutionPipeline))! as IStoredProcedureExecutionPipeline)!;
    }
}
