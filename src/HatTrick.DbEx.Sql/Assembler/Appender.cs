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
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Appender : IAppender
    {
        #region internals
        private readonly StringBuilder builder = new(512);
        #endregion

        #region interface
        public AppenderIndentation Indentation { get; set; }
        #endregion

        #region constructors
        public Appender()
        {
            Indentation = new AppenderIndentation(this);
        }
        #endregion

        #region methods
        public IAppender LineBreak()
        {
            builder.Append(Environment.NewLine);
            return this;
        }

        public IAppender Write(string value)
        {
            if (value is null)
                return this;

            builder.Append(value);

            return this;
        }

        public IAppender Write(char value)
        {
            if (value == default)
                return this;

            builder.Append(value);

            return this;
        }

        public IAppender Indent()
        {
            for (byte i = 0; i < Indentation.CurrentLevel; i++)
                builder.Append('\t');

            return this;
        }

        public IAppender If(bool append, params Action<Appender>[] values)
        {
            if (!append)
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        public IAppender IfNotEmpty(string test, params Action<Appender>[] values)
        {
            if (string.IsNullOrWhiteSpace(test))
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        public override string ToString() => builder.ToString();
        #endregion
    }
}
