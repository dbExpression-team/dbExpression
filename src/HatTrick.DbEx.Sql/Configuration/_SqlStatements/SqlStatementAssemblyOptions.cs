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

﻿namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblyOptions
    {
        public bool PrependCommaOnSelectClause { get; set; } = false;
        public Delimeters IdentifierDelimiter { get; set; } = new Delimeters('[', ']');
        public char StatementTerminator { get; set; } = ';';

        public class Delimeters
        {
            public char Begin { get; set; } = '[';
            public char End { get; set; } = ']';

            public Delimeters(char begin, char end)
            {
                Begin = begin;
                End = end;
            }
        }
    }
}
