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
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools
{
    public class Tokenizer
    {
        #region internals
        private object _lock;
        private char[] _delims;
        private readonly char _delimEscape = '\\';

        private int _index;
        private int _length;

        private string _expression;
        private bool _maintainQuotes;

        private char[] _token;
        #endregion

        #region interface
        public Action<string> Emit { get; set; }
        #endregion

        #region constructor
        public Tokenizer(char[] delimiters, int maxLen = 256, bool maintainQuotes = false)
        {
            _lock = new object();
            _expression = null;
            _delims = delimiters;
            _length = 0;
            _index = 0;
            _token = new char[maxLen];
            _maintainQuotes = maintainQuotes;
        }
        #endregion

        #region parse
        public void Parse(string expression)
        {
            lock (_lock)
            {
                _expression = expression;
                _length = expression.Length;
                string token;
                while ((token = this.Walk()) is object)
                {
                    this.Emit(token);
                }
                _expression = null;
                _index = 0;
                _length = 0;
            }
        }
        #endregion

        #region walk
        private string Walk()
        {
            string token = null;
            char c;
            int len = 0;
            bool inQuotes = false;
            while (_index < _length && token is null)
            {
                c = _expression[_index];
                if (c == _delimEscape && !inQuotes)
                {
                    char next = _expression[_index + 1];
                    if (this.DelimsContains(next) || next == '"')
                    {
                        _token[len++] = _expression[++_index];
                    }
                    else
                    {
                        _token[len++] = c;
                    }
                }
                else if (c == '"')
                {
                    inQuotes = !inQuotes; //negate...
                    if (_maintainQuotes)
                    {
                        _token[len++] = c;
                    }
                    if (_index == (_length - 1) && len > 0)
                    {
                        token = new string(_token, 0, len);
                    }
                }
                else if (this.DelimsContains(c) && !inQuotes)
                {
                    if (len > 0) //if len == 0, delimiter was at _index 0 or we encoutered a sequence of multiple delimiters...
                    {
                        token = new string(_token, 0, len);
                    }
                }
                else
                {
                    _token[len++] = c;
                    if (_index == (_length - 1) && len > 0)
                    {
                        token = new string(_token, 0, len);
                    }
                }
                _index += 1;
            }


            return token;
        }
        #endregion

        #region delims contains
        private bool DelimsContains(char value)
        {
            char[] delims = _delims;
            bool found = false;
            for (int i = 0; i < delims.Length; i++)
            {
                if (delims[i] == value)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        #endregion
    }
}
