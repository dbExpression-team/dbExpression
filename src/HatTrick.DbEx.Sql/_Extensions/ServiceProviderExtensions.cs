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
using HatTrick.DbEx.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<TDatabase>());
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
            var runtime = provider.GetRequiredService(database) as ISqlDatabaseRuntime;
            try
            {
                runtime!.InitializeStaticRuntime();
                var logger = provider.GetService(typeof(ILogger<>).MakeGenericType(new[] { database })) as ILogger;
                if (logger is not null)
                    logger.LogInformation("{database} can be used statically with dbExpression.", database.Name);

                return;
            }
            catch (Exception e)
            {
                throw new DbExpressionConfigurationException(ExceptionMessages.InitializeStaticRuntime(database), e);
            }
        }

        public static bool IsRegisteredIn<TDatabase, T>(this IServiceProvider provider)
            where TDatabase : class, ISqlDatabaseRuntime
            where T : class
            => provider.IsRegisteredIn<TDatabase>(typeof(T));

        public static bool IsRegisteredIn<TDatabase>(this IServiceProvider provider, Type type)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (provider is IServiceProvider<TDatabase> sp)
                return sp.IsRegistered(type);

            return false;
        }
    }
}
