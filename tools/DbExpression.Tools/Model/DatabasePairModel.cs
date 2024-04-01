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

using HatTrick.Model.MsSql;
using HatTrick.Model.Sql;
using System;
using System.Collections.Generic;

namespace DbExpression.Tools.Model
{
    public class DatabasePairModel<T>
        where T : class, ISqlModel
    {
        public int Identifier { get; }
        public PlatformModel Platform { get; set; }
        public PackageCompatibilityModel PackageCompatibility { get; set; }
        public RuntimeModel Runtime { get ; set; }
        public LanguageFeaturesModel LanguageFeatures { get; set; }
        public T Database { get; set; }
        public DatabaseExpressionModel DatabaseExpression { get; set; }
        public IList<SchemaPairModel> Schemas { get; set; } = new List<SchemaPairModel>();
        public DocumentationItemsModel<T>? Documentation { get; set; }

        public DatabasePairModel(int identifier, PlatformModel platform, PackageCompatibilityModel packageCompatibility, RuntimeModel runtime, T database, DatabaseExpressionModel databaseExpression, LanguageFeaturesModel features)
        {
            Identifier = identifier;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            PackageCompatibility =  packageCompatibility ?? throw new ArgumentNullException(nameof(packageCompatibility));
            Runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            Database = database ?? throw new ArgumentNullException(nameof(database));
            DatabaseExpression = databaseExpression ?? throw new ArgumentNullException(nameof(databaseExpression));
            LanguageFeatures = features ?? throw new ArgumentNullException(nameof(features));
        }
    }
}
