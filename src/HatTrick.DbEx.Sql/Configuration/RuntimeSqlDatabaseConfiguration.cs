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

﻿using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseConfiguration
    {
        #region interface
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ISqlDatabaseMetadataProvider MetadataProvider { get; set; }
        public IQueryExpressionFactory QueryExpressionFactory { get; set; }
        public IQueryExecutionPipelineFactory ExecutionPipelineFactory { get; set;  }
        public ISqlStatementAssemblerFactory StatementAssemblerFactory { get; set; }
        public ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public IExpressionElementAppenderFactory ExpressionElementAppenderFactory { get; set; }
        public IAppenderFactory AppenderFactory { get; set; }
        public ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public ISqlStatementExecutorFactory StatementExecutorFactory { get; set; }
        public ISqlConnectionFactory ConnectionFactory { get; set; }
        public IConnectionStringFactory ConnectionStringFactory { get; set; }
        public IMapperFactory MapperFactory { get; set; }
        public IEntityFactory EntityFactory { get; set; }
        public IValueConverterFactory ValueConverterFactory { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SqlStatementAssemblerConfiguration AssemblerConfiguration { get; set; } = new SqlStatementAssemblerConfiguration();
        #endregion
    }
}
