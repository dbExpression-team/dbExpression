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

﻿using HatTrick.DbEx.Sql;
using System.Data;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlColumnMetadata : SqlColumnMetadata
    {

        public MsSqlColumnMetadata(string name, SqlDbType dbType)
            : base(name, dbType)
        {
        }

        public MsSqlColumnMetadata(string name, SqlDbType dbType, int size)
            : base(name, dbType, size)
        {
        }

        public MsSqlColumnMetadata(string name, SqlDbType dbType, byte precision, byte scale)
            : base(name, dbType, precision, scale)
        {
        }
    }
}
