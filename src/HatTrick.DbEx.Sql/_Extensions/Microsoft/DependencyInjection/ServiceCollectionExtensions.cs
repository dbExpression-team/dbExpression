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

using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure and add one or more databases to the service collection for use with dbExpression.
        /// </summary>
        /// <param name="services">The service collection to add database services provided via each configuration delegate in <paramref name="databases"/>.</param>
        /// <param name="databases">Build the configuration of each database in the list.</param>
        /// <exception cref="DbExpressionConfigurationException">Exceptions thrown during configuration will be captured and included as in inner exception of type <see cref="AggregateException"/>.</exception>
        public static void AddDbExpression(this IServiceCollection services, params Action<ISqlDatabaseRuntimeServicesBuilder>[] databases)
        {
            List<Exception> exceptions = new();
            var builder = new SqlDatabaseRuntimeRegistrar(services);
            foreach (var database in databases)
            {
                try
                {
                    database.Invoke(builder);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }
            if (exceptions.Any())
                throw new DbExpressionConfigurationException(ExceptionMessages.DatabaseBuilderAggregate(), new AggregateException(exceptions));

            //configuration of all databases succeeded, register all database types in the service collection for reference 
            builder.RegisterAllDatabaseTypes();
        }
    }
}
