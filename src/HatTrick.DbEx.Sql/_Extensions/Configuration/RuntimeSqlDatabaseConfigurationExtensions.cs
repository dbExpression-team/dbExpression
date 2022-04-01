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

﻿using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Configuration
{
    public static class RuntimeSqlDatabaseConfigurationExtensions
    {
        public static void Validate(this SqlDatabaseRuntimeConfiguration configuration)
        {
            if (!configuration.TryValidate(out List<string> validationErrors))
                throw new DbExpressionConfigurationException($"Database configuration is invalid.  The following factories/providers have not been configured: {string.Join(", ", validationErrors)}.");
        }

        public static bool TryValidate(this SqlDatabaseRuntimeConfiguration configuration, out List<string> validationErrors)
        {
            var validations = new List<string>();
            try
            {
                void addIfNull(string configProperty, object configurationItem) { if (configurationItem is null) validations.Add(configProperty); }

                addIfNull(nameof(configuration.AppenderFactory), configuration.AppenderFactory);
                addIfNull(nameof(configuration.ConnectionFactory), configuration.ConnectionFactory);
                addIfNull(nameof(configuration.ConnectionStringFactory), configuration.ConnectionStringFactory);
                addIfNull(nameof(configuration.EntityFactory), configuration.EntityFactory);
                addIfNull(nameof(configuration.ExecutionPipelineFactory), configuration.ExecutionPipelineFactory);
                addIfNull(nameof(configuration.ExpressionElementAppenderFactory), configuration.ExpressionElementAppenderFactory);
                addIfNull(nameof(configuration.MapperFactory), configuration.MapperFactory);
                addIfNull(nameof(configuration.MetadataProvider), configuration.MetadataProvider);
                addIfNull(nameof(configuration.ParameterBuilderFactory), configuration.ParameterBuilderFactory);
                addIfNull(nameof(configuration.QueryExpressionFactory), configuration.QueryExpressionFactory);
                addIfNull(nameof(configuration.StatementBuilderFactory), configuration.StatementBuilderFactory);
                addIfNull(nameof(configuration.StatementAssemblerFactory), configuration.StatementAssemblerFactory);
                addIfNull(nameof(configuration.StatementExecutorFactory), configuration.StatementExecutorFactory);
                addIfNull(nameof(configuration.ValueConverterFactory), configuration.ValueConverterFactory);
            }
            catch
            {
                validationErrors = validations;
                return false;
            }

            validationErrors = validations;
            return !validationErrors.Any();
        }
    }
}
