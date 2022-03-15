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

using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.Sql
{
    public abstract class SqlDatabaseRuntime<T> : ISqlDatabaseRuntime<T>
        where T : SqlDatabaseRuntimeConfiguration, new()
    {
        #region internals
        private T? _configuration;
        #endregion

        #region interface
        protected T Configuration => _configuration ?? throw new DbExpressionConfigurationException($"the database '{GetType()}' has not been properly configured for runtime use with dbExpression.");

        #endregion

        #region constructors
        protected SqlDatabaseRuntime()
        {

        }

        protected SqlDatabaseRuntime(T configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public virtual void UseConfiguration(T configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion
    }
}
