﻿#region license
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

using DbExpression.Sql;

namespace DbExpression.MsSql
{
    public class MsSqlParameterMetadata : SqlParameterMetadata
    {
        public MsSqlParameterMetadata(string name, object dbType)
            : base(name, dbType)
        {
        }

        public MsSqlParameterMetadata(string name, object dbType, int size)
            : base(name, dbType, size)
        {
        }

        public MsSqlParameterMetadata(string name, object dbType, byte precision, byte scale)
            : base(name, dbType, precision, scale)
        {
        }
    }
}
