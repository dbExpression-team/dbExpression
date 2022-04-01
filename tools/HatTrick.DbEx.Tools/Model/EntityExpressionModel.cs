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
using System.Collections.Generic;

namespace HatTrick.DbEx.Tools.Model
{
    public class EntityExpressionModel
    {
        public LanguageFeatures LanguageFeatures { get; }
        public SchemaExpressionModel SchemaExpression { get; }
        public string NamespaceRoot => SchemaExpression.NamespaceRoot;
        public string Name { get; }
        public IEnumerable<string> AppliedInterfaces { get; }
        public string EntityInitializer => !string.IsNullOrWhiteSpace(LanguageFeatures.Nullable.ForgivingOperator) ? " = null!;" : string.Empty;
        
        public Dictionary<string, string> ArgNamePsuedonyms = new()
        {
            { "identifier", "identifier" },
            { "name", "name" },
            { "schema", "schema" },
            { "alias", "alias" },
            { "source", "source" },
            { "target", "target" },
            { "entity", "entity" }
        };

        public EntityExpressionModel(LanguageFeatures features, SchemaExpressionModel schema, string name, IList<string> interfaces)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            SchemaExpression = schema ?? throw new ArgumentNullException(nameof(schema));
            Name = name;
            AppliedInterfaces = interfaces;
        }

        public override string ToString()
            => $"{Name}Entity";
    }
}
