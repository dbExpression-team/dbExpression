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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql
{
    public static class ServiceProviderExtensions
    {
        public static void UseStaticRuntimeFor<TDatabase>(this IServiceProvider provider)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            var databases = provider.GetRequiredService<RegisteredSqlDatabaseRuntimeTypes>();
            var database = databases.SingleOrDefault(x => x == typeof(TDatabase));
            if (database is null)
                throw new DbExpressionConfigurationException($"The database {typeof(TDatabase)} has not been added to services, ensure the database has been added to the service collection via {nameof(ServiceCollectionExtensions.AddDbExpression)}.");

            provider.InitializeStaticRuntime(database);
        }

        internal static void InitializeStaticRuntimes(this IServiceProvider provider)
        {
            var databases = provider.GetRequiredService<RegisteredSqlDatabaseRuntimeTypes>();
            foreach (var database in databases)
            {
                provider.InitializeStaticRuntime(database);
            }
        }

        private static void InitializeStaticRuntime(this IServiceProvider provider, Type database)
        {
            var factoryType = typeof(SingletonSqlDatabaseRuntimeFactory<>).MakeGenericType(new[] { database });
            var factory = provider.GetService(factoryType) as SingletonSqlDatabaseRuntimeFactory;
            factory!.GetInstance().InitializeStaticRuntime();
        }
    }
}
