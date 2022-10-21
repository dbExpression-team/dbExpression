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

using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : IDbConnectionFactory
    {
        #region internals
        private readonly IConnectionStringFactory connectionStringFactory;
        #endregion

        #region constructors
        public MsSqlConnectionFactory(IConnectionStringFactory connectionStringFactory)
        { 
            this.connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException(nameof(connectionStringFactory));
        }
        #endregion

        #region methods
        public IDbConnection CreateSqlConnection()
        {
            var connectionString = connectionStringFactory.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("The provided connection string is null or empty.  Cannot create a database connection.");
            return new SqlConnection(connectionString);
        }
        #endregion
    }
}
