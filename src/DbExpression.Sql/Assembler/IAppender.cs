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

namespace DbExpression.Sql.Assembler
{
    public interface IAppender : IDisposable
    {
        AppenderIndentation Indentation { get; set; }

        IAppender LineBreak();

        IAppender Write(string value);

        IAppender Write(char value);
        IAppender Indent();

        IAppender If(bool append, params Action<IAppender>[] values);

        IAppender IfNotEmpty(string test, params Action<IAppender>[] values);

        string? ToString();
    }
}
