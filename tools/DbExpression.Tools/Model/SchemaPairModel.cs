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

﻿using System;
using System.Collections.Generic;

namespace DbExpression.Tools.Model
{
    public class SchemaPairModel
    { 
        public int Identifier { get; }
        public PlatformModel Platform { get; set; }
        public SchemaModel Schema { get; }
        public SchemaExpressionModel SchemaExpression { get; }
        public IList<EntityPairModel> Entities { get; } = new List<EntityPairModel>();
        public IList<StoredProcedurePairModel> StoredProcedures { get; } = new List<StoredProcedurePairModel>();

        public SchemaPairModel(int identifier, PlatformModel platform, SchemaModel schema, SchemaExpressionModel schemaExpression)
        {
            Identifier = identifier;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            SchemaExpression = schemaExpression ?? throw new ArgumentNullException(nameof(schemaExpression));
        }

        public override string ToString()
            => $"({Schema}, {SchemaExpression})";
    }
}
