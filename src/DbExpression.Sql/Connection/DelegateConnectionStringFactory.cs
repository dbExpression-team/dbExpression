#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using System;

namespace DbExpression.Sql.Connection
{
    public class DelegateConnectionStringFactory : IConnectionStringFactory
    {
        #region internals
        private readonly Func<string> factory;
        #endregion

        #region constructors
        public DelegateConnectionStringFactory(Func<string> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DelegateConnectionStringFactory(Func<IConnectionStringFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            this.factory = () => factory()?.GetConnectionString() ?? throw new DbExpressionException(ExceptionMessages.NullValueUnexpected());
        }
        #endregion

        #region methods
        public string GetConnectionString()
            => factory();
        #endregion
    }
}
