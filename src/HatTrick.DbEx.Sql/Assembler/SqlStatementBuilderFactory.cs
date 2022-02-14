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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region methods
        public virtual ISqlStatementBuilder CreateSqlStatementBuilder(RuntimeSqlDatabaseConfiguration database, QueryExpression expression)
            => new SqlStatementBuilder(
                expression,
                database.MetadataProvider ?? throw new DbExpressionConfigurationException($"Could not resolve a metadata provider, please ensure a metadata provider has been registered during startup initialization of dbExpression."),
                database.StatementAssemblerFactory ?? throw new DbExpressionConfigurationException($"Could not resolve a sql statement assembler factory, please ensure a sql statement assembler factory has been registered during startup initialization of dbExpression."),
                database.AssemblerConfiguration ?? throw new DbExpressionConfigurationException($"Could not resolve assembler configuration, please ensure assembler configuration has been registered during startup initialization of dbExpression."),
                database.ExpressionElementAppenderFactory ?? throw new DbExpressionConfigurationException($"Could not resolve an expression element appender, please ensure an expression element appender has been registered during startup initialization of dbExpression."),
                database.AppenderFactory ?? throw new DbExpressionConfigurationException($"Could not resolve an appender, please ensure a an appender has been registered during startup initialization of dbExpression."),
                database.ParameterBuilderFactory ?? throw new DbExpressionConfigurationException($"Could not resolve a parameter builder factory, please ensure a parameter builder factory has been registered during startup initialization of dbExpression.")
            );
        #endregion
    }
}