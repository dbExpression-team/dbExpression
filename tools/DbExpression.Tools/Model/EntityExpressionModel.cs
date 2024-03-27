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
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace DbExpression.Tools.Model
{
    public class EntityExpressionModel
    {
        public string[] AllImplementations => BuildImplementationList();
        public LanguageFeaturesModel LanguageFeatures { get; }
        public SchemaExpressionModel SchemaExpression { get; }
        public string NamespaceRoot => SchemaExpression.NamespaceRoot;
        public string Name { get; }
        public string? BaseType { get; }
        public IEnumerable<string> AppliedInterfaces { get; }
        public string EntityInitializer => !string.IsNullOrWhiteSpace(LanguageFeatures.Nullable.ForgivingOperator) ? " = null!;" : string.Empty;
        
        public EntityExpressionModel(LanguageFeaturesModel features, SchemaExpressionModel schema, string name, string? baseType, IList<string> interfaces)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            SchemaExpression = schema ?? throw new ArgumentNullException(nameof(schema));
            Name = name;
            BaseType = baseType;
            AppliedInterfaces = interfaces;
        }

        public string[] BuildImplementationList()
        {
            var result = new List<string>();
            if (!string.IsNullOrWhiteSpace(BaseType))
                result.Add(BaseType);
            result.AddRange(AppliedInterfaces);
            return result.ToArray();
        }

        public override string ToString()
            => $"{Name}Entity";
    }
}
