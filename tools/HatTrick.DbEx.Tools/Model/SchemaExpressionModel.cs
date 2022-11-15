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
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class SchemaExpressionModel
    {
        public LanguageFeaturesModel LanguageFeatures { get; }
        public DatabaseExpressionModel DatabaseExpression { get; }
        public string NamespaceRoot { get; }
        public string Name { get; }

        public Dictionary<string, string> ArgNamePsuedonyms = new()
        {
            { "identifier", "identifier" },
            { "name", "name" },
            { "alias", "alias" },
            { "schema", "schema" }
        };

        public SchemaExpressionModel(LanguageFeaturesModel features, DatabaseExpressionModel database, MsSqlSchema schema, string namespaceRoot, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            DatabaseExpression = database ?? throw new ArgumentNullException(nameof(database));
            Name = name;
            NamespaceRoot = namespaceRoot;
        }

        public override string ToString()
            => $"{Name}Schema";
    }
}
