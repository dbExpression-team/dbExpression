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

﻿using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AppenderIndentation
    {
        #region internals
        private readonly IAppender appender;
        #endregion

        #region interface
        public byte CurrentLevel { get; set; }
        #endregion

        #region constructors
        public AppenderIndentation(IAppender appender)
        {
            this.appender = appender;
        }
        #endregion

        #region operators
        public static AppenderIndentation operator ++(AppenderIndentation a)
        {
            a.CurrentLevel++;
            return a;
        }

        public static AppenderIndentation operator --(AppenderIndentation a)
        {
            if (a.CurrentLevel > 0)
            {
                a.CurrentLevel--;
            }
            return a;
        }
        #endregion

        #region methods
        public IAppender Write(string value)
            => appender.Write(value);

        public IAppender Write(char value)
            => appender.Write(value);

        public IAppender If(bool append, params Action<IAppender>[] values)
            => appender.If(append, values);

        public IAppender IfNotEmpty(string test, params Action<IAppender>[] values)
            => appender.IfNotEmpty(test, values);

        public IAppender Indent()
            => appender.Indent();

        public IAppender LineBreak()
            => appender.LineBreak();
        #endregion
    }
}
