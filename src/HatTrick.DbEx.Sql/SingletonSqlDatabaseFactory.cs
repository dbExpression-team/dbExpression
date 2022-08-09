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

namespace HatTrick.DbEx.Sql
{
    public abstract class SingletonSqlDatabaseRuntimeFactory
    {
        #region internals
        private readonly Func<ISqlDatabaseRuntime> _factory;
        private readonly Type _databaseType;
        private static ISqlDatabaseRuntime? _singleton;
        private readonly object _lock = new();
        #endregion

        #region constructors
        public SingletonSqlDatabaseRuntimeFactory(Type databaseType, Func<ISqlDatabaseRuntime> factory)
        {
            _databaseType = databaseType ?? throw new ArgumentNullException(nameof(databaseType));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public ISqlDatabaseRuntime GetInstance()
        {
            if (_singleton is not null)
                return _singleton;

            lock (_lock)
            {
                if (_singleton is not null)
                    return _singleton;

                _singleton = _factory.Invoke();            
            }

            return _singleton;
        }
        #endregion
    }
}
