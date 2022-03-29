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
        private const string t1 = "\t";
        private const string t2 = "\t\t";
        private const string t3 = "\t\t\t";
        private const string t4 = "\t\t\t\t";
        private const string t5 = "\t\t\t\t\t";
        private const string t6 = "\t\t\t\t\t\t";
        private const string t7 = "\t\t\t\t\t\t\t";
        private const string t8 = "\t\t\t\t\t\t\t\t";
        private const string t9 = "\t\t\t\t\t\t\t\t\t";
        private const string t10 = "\t\t\t\t\t\t\t\t\t\t";

        private static readonly string[] tabs = new string[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };

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
            if (Indentation.CurrentLevel == 0)
                return this;

            if (Indentation.CurrentLevel < tabs.Length)
            {
                builder.Append(tabs[Indentation.CurrentLevel - 1]);
            }
            else
            {
#pragma warning disable IDE0079
#pragma warning disable IDE0056 // Use index operator: [supporting netstandard2.0, indexing not supported]
                builder.Append(tabs[tabs.Length - 1]);
#pragma warning restore IDE0056 // Use index operator
#pragma warning restore IDE0079
                for (var i = tabs.Length; i < Indentation.CurrentLevel; i++)
                    builder.Append('\t');
            }

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
