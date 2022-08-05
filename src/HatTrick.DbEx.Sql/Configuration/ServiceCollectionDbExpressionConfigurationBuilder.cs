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

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ServiceCollectionDbExpressionConfigurationBuilder : 
        ISqlDatabaseRuntimeServicesBuilder,
        ISqlDatabaseRuntimeServicesRegistrar
    {
        private readonly IServiceCollection _services;
        private List<Type> _databases = new();

        public IList<Type> Databases => _databases;
        public IServiceCollection Services => _services;

        public IServiceCollection ServicesFor<TDatabase>()
            where TDatabase : class, ISqlDatabaseRuntime
        {
            _databases.Add(typeof(TDatabase));
            return _services;
        }

        public ServiceCollectionDbExpressionConfigurationBuilder(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }        
    }
}
