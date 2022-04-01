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
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class DatabaseServiceFactory<TDatabase, TService> : DatabaseService<TDatabase, TService>
        where TDatabase : class, ISqlDatabaseRuntime
        where TService : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Func<IServiceProvider, object> _instanceFactory;
        public override TService? Service => _instanceFactory(_serviceProvider) as TService;

        public DatabaseServiceFactory(IServiceProvider serviceProvider, Func<IServiceProvider, object> instanceFactory)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _instanceFactory = instanceFactory ?? throw new ArgumentNullException(nameof(instanceFactory));
        }
    }
}
