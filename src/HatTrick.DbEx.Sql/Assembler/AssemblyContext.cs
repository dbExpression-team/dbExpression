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

using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssemblyContext
    {
        #region internals
        private readonly Stack<FieldExpressionAppendStyle> fieldStyles = new();
        private readonly Stack<EntityExpressionAppendStyle> entityStyles = new();
        private readonly IDictionary<Type,object> state = new ConcurrentDictionary<Type,object>();
        #endregion

        #region interface
        public bool IncludeSchemaName { get; set; } = true;
        public bool PrependCommaOnSelectClause { get; set; } = false;
        public SqlStatementAssemblyOptions.Delimeters IdentifierDelimiter { get; set; } = new SqlStatementAssemblyOptions.Delimeters('[', ']');
        public char StatementTerminator { get; set; } = ';';
        public FieldExpressionAppendStyle FieldExpressionAppendStyle => fieldStyles.FirstOrDefault();
        public EntityExpressionAppendStyle EntityExpressionAppendStyle => entityStyles.FirstOrDefault();
        public bool TrySharingExistingParameter { get; set; }
        #endregion

        #region constructors
        public AssemblyContext()
        {
            //set defaults
            fieldStyles.Push(FieldExpressionAppendStyle.None);
            entityStyles.Push(EntityExpressionAppendStyle.None);
        }
        #endregion

        #region methods
        public void PushAppendStyles(EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            entityStyles.Push(entityAppendStyle);
            fieldStyles.Push(fieldAppendStyle);
        }

        public void PushFieldAppendStyle(FieldExpressionAppendStyle fieldAppendStyle)
            => fieldStyles.Push(fieldAppendStyle);

        public void PushEntityAppendStyle(EntityExpressionAppendStyle entityAppendStyle)
            => entityStyles.Push(entityAppendStyle);

        public void PopAppendStyles()
        {
            if (entityStyles.Any())
                entityStyles.Pop();
            if (fieldStyles.Any())
                fieldStyles.Pop();
        }

        public void PopEntityAppendStyle()
        {
            if (entityStyles.Any())
                entityStyles.Pop();
        }

        public void PopFieldAppendStyle()
        {
            if (fieldStyles.Any())
                fieldStyles.Pop();
        }

        public void SetState<T>()
            where T : class, new()
            => this.state.Add(typeof(T), new T());

        public void SetState<T>(T state)
            where T : class
            => this.state.Add(typeof(T), state);

        public T? GetState<T>()
            where T : class
        {
            if (state.TryGetValue(typeof(T), out var s))
                return s as T;
            return default;
        }

        public T? RemoveState<T>()
            where T : class
        {
            var existing = GetState<T>();
            if (existing is not null)
                state.Remove(typeof(T));
            return existing;
        }
        #endregion
    }
}
