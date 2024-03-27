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

using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace DbExpression.Sql.Assembler
{
    public class Appender : IAppender
    {
        #region internals
        private static readonly char[] NewLine = Environment.NewLine.ToCharArray();
        private bool disposed = false;
        private int currentPosition = 0;
        private char[] current = Array.Empty<char>();
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
            foreach (var c in NewLine)
                Write(c);
            return this;
        }

        public IAppender Write(string value)
        {
            foreach (var c in value)
                Write(c);
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAppender Write(char value)
        {
            if (value == default)
                return this;

            if (current.Length == 0 || currentPosition == current.Length)
            {
                GrowAndAppend(value);
                return this;
            }

            current[currentPosition] = value;
            currentPosition++;

            return this;
        }

        public IAppender Indent()
        {
            for (byte i = 0; i < Indentation.CurrentLevel; i++)
                Write('\t');

            return this;
        }

        public IAppender If(bool append, params Action<IAppender>[] values)
        {
            if (!append)
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        public IAppender IfNotEmpty(string test, params Action<IAppender>[] values)
        {
            if (string.IsNullOrWhiteSpace(test))
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        public override string ToString()
        {
            int snapshotCurrentPosition = currentPosition;
            currentPosition = 0;

#if NET7_0_OR_GREATER
            return string.Create(snapshotCurrentPosition, current, (asString, _) => current.AsSpan().Slice(0, snapshotCurrentPosition).CopyTo(asString));
#else
            return new string(current.AsSpan().Slice(0, snapshotCurrentPosition).ToArray());
#endif
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void GrowAndAppend(char c)
        {
            Grow(1);
            Write(c);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int size)
        {
            char[] rented = ArrayPool<char>.Shared.Rent((int)Math.Max((uint)(currentPosition + size), (uint)(current.Length * 2)));
            current.AsSpan().Slice(0, currentPosition).CopyTo(rented);
            ArrayPool<char>.Shared.Return(current);
            current = rented;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed || disposing)
                return;

            ArrayPool<char>.Shared.Return(current);
            currentPosition = 0;
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
