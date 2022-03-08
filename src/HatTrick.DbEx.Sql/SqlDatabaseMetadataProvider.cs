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

using System;
﻿using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql
{
    public class SqlDatabaseMetadataProvider : ISqlDatabaseMetadataProvider
    {
        #region internals
        private ConcurrentDictionary<string, ISqlEntityMetadata> _discoveredEntities = new();
        private ConcurrentDictionary<string, ISqlFieldMetadata> _discoveredFields = new();
        private ConcurrentDictionary<string, ISqlParameterMetadata> _discoveredParameters = new();
        #endregion

        #region interface
        public ISqlDatabaseMetadata Database { get; private set; }
        #endregion

        #region constructors
        public SqlDatabaseMetadataProvider(ISqlDatabaseMetadata metadata)
        {
            Database = metadata ?? throw new ArgumentNullException(nameof(metadata));
        }
        #endregion

        #region methods
        public ISqlSchemaMetadata? FindSchemaMetadata(string identifier)
        {
            if (Database.Schemas.TryGetValue(identifier, out var meta))
                return meta;
            return null;
        }

        public ISqlEntityMetadata? FindEntityMetadata(string identifier)
        {
            if (_discoveredEntities.TryGetValue(identifier, out var entity))
                return entity;

            foreach (var schema in Database.Schemas)
                if (schema.Value.Entities.TryGetValue(identifier, out var meta))
                {
                    _discoveredEntities.TryAdd(identifier, meta);
                    return meta;
                }

            return null;
        }

        public ISqlFieldMetadata? FindFieldMetadata(string identifier)
        {
            if (_discoveredFields.TryGetValue(identifier, out var field))
                return field;

            foreach (var schema in Database.Schemas)
                foreach (var table in schema.Value.Entities)
                    if (table.Value.Fields.TryGetValue(identifier, out var meta))
                    {
                        _discoveredFields.TryAdd(identifier, meta);
                        return meta;
                    }

            return null;
        }

        public ISqlParameterMetadata? FindParameterMetadata(string identifier)
        {
            if (_discoveredParameters.TryGetValue(identifier, out var parameter))
                return parameter;

            foreach (var schema in Database.Schemas)
                foreach (var procedure in schema.Value.StoredProcedures)
                    if (procedure.Value.Parameters.TryGetValue(identifier, out var meta))
                    {
                        _discoveredParameters.TryAdd(identifier, meta);
                        return meta;
                    }

            return null;
        }
        #endregion
    }
}
