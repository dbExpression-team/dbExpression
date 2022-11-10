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

﻿using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Tools.Model
{
    public class TableModel : ISqlEntityModel
    {
        public SchemaModel Schema { get; }
        public string Name { get; }
        public string TypeIdentifier => "table";
        public IDictionary<string, string> Properties { get; }
        public IList<(string, IDictionary<string, string>)> Indexes { get; }

        public TableModel(SchemaModel schema, MsSqlTable table)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            Name = table?.Name ?? throw new ArgumentNullException(nameof(table));
            Properties = new Dictionary<string, string> { { "name", table.Name } };
            Indexes = BuildIndexDocumentationMetadata(table).ToList();
        }

        public override string ToString()
            => $"[{Schema.Name}].[{Name}]";

        private IEnumerable<(string, IDictionary<string, string>)> BuildIndexDocumentationMetadata(INamedMeta meta)
        {
            if (meta is MsSqlTable table)
            {
                foreach (var index in table.Indexes)
                {
                    var attributes = new Dictionary<string, string>();
                    if (index.IsPrimaryKey)
                        attributes.Add("primary key", "yes");
                    attributes.Add("columns", index.IndexedColumns.Aggregate(string.Empty, (s, column) => $"{s}{column.Name}{(column != index.IndexedColumns.Last() ? ", " : string.Empty)}"));

                    yield return (index.Name, attributes);
                }
            }
            yield break;
        }        
    }
}
