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

namespace DbExpression.Tools.Model
{
    public class DatabaseExpressionModel
    {
        public LanguageFeaturesModel LanguageFeatures { get; }
        public string NamespaceRoot { get; }
        public string Name { get; }
        public RuntimeModel Runtime { get; }

        public DatabaseExpressionModel(RuntimeModel runtime, LanguageFeaturesModel features, string name, string namespaceRoot)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is required.");
            if (string.IsNullOrWhiteSpace(namespaceRoot))
                throw new ArgumentException($"{nameof(namespaceRoot)} is required.");
            Runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
            Name = name;
            NamespaceRoot = namespaceRoot;
        }

        public override string ToString()
            => Name;
    }
}
