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
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DbExpression.Tools.Service
{
    public abstract class ExecutionContext
    {
        #region internals
        private readonly string _command;
        private readonly string? _options;
        private readonly Stopwatch _stopWatch = new();
        private readonly string _tab = new(' ', 2);
        #endregion

        #region interface
        public string Command => _command;

        public Dictionary<string, string> Options { get; private set; } = new();

        public string WorkingDirectory
        { 
            get { return Directory.GetCurrentDirectory(); }
            set { Directory.SetCurrentDirectory(value); }
        }

        public string Tab => _tab;
        #endregion

        #region constructor
        public ExecutionContext(string command) : this(command, null)
        {
        }

        public ExecutionContext(string command, string? options)
        {
            _command = command;
            _options = options;
        }
        #endregion

        #region execute
        public virtual void Execute()
        {
            _stopWatch.Start();
        }
		#endregion

		#region ensure options
		protected void EnsureOptions(params string[] validOptions)
        {
            if (_options is not null)
            {
                List<string> options = new();
                Tokenizer tokenizer = new(new char[] { ' ' });
                tokenizer.Emit += (t) =>
                {
                    options.Add(t);
                };
                tokenizer.Parse(_options);

                if (options.Count > 0)
                {
                    this.Options = new Dictionary<string, string>();
                    string? key = null;
                    string? value = null;

                    for (int i = 0; i < options.Count; i++)
                    {
                        key = options[i];
                        if (!Array.Exists(validOptions, (o) => o == key))
                        {
                            throw new CommandException($"Encountered unknown command option: {key}");
                        }
                        if (options.Count > (i + 1) && !options[i + 1].StartsWith('-'))
                        {
                            value = options[++i];
                        }
                        this.Options.Add(key, value ?? "true");
                        key = null;
                        value = null;
                    }
                }
            }
        }
        #endregion

        #region requested help
        public bool HelpOptionExists()
        {
            return this.TryGetOption(out string? _, out string? _, "--help", "-?");
        }
        #endregion

        #region try get option 
        public bool TryGetOption(out string? value, out string? keyUsed, params string[] key)
        {
            value = null;
            keyUsed = null;
            bool found = false;
            if (this.Options is not null)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    found = this.Options.TryGetValue(key[i], out value);
                    if (found)
                    {
                        keyUsed = key[i];
                        break;
                    }
                }
            }
            return found;
        }
        #endregion

        #region complete
        public void Complete()
        {
            _stopWatch.Stop();
        }
        #endregion
    }
}
