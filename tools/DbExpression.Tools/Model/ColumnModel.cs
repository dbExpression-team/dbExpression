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

﻿using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DbExpression.Tools.Model
{
    public class ColumnModel
    {
        public ISqlEntityModel Entity { get; }
        public string Name { get; }
        public bool IsNullable { get; }
        public bool IsIdentity { get; }
        public bool IsComputed { get; }
        public long? Size { get; }
        public byte? Precision { get; }
        public byte? Scale { get; }
        public IDictionary<string, string> Properties { get; }
        public SqlDbType SqlType { get; }

        public ColumnModel(ISqlEntityModel entity, MsSqlColumn column)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Properties = BuildColumnDocumentationMetadata(column ?? throw new ArgumentNullException(nameof(column)));
            Name = column.Name;
            IsNullable = column.IsNullable;
            IsIdentity = column.IsIdentity;
            IsComputed = column.IsComputed;
            Size = column.SqlType.SupportsSize() ? column.MaxLength == 0 ? (short?)null : column.MaxLength : null;
            Precision = column.SqlType.SupportsPrecision() ? column.Precision == 0 ? (byte?)null : column.Precision : null;
            Scale = column.SqlType.SupportsPrecision() ? column.Scale == 0 ? (byte?)null : column.Scale : null;
            SqlType = column.SqlType;
        }

        public override string ToString()
            => $"[{Entity.Schema.Name}].[{Entity.Name}].[{Name}]";

        private IDictionary<string, string> BuildColumnDocumentationMetadata(MsSqlColumn column)
        {
            var attributes = new Dictionary<string, string>();

            attributes.Add("name", column.Name);
            attributes.Add("sql type", column.SqlType.ToFriendlyName(column.MaxLength, column.Precision, column.Scale));
            attributes.Add("allow null", column.IsNullable ? "yes" : "no");
            if (!string.IsNullOrWhiteSpace(column.DefaultDefinition))
                attributes.Add("default", column.DefaultDefinition);
            if (column.IsIdentity)
                attributes.Add("identity", "yes");
            if (column.IsComputed)
                attributes.Add("computed", "yes");

            return attributes;
        }
    }
}
