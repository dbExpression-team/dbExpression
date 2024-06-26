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
    public class EntityPairModel
    {
        public int Identifier { get; }
        public PlatformModel Platform { get; set; }
        public ISqlEntityModel Entity { get; }
        public EntityExpressionModel EntityExpression { get; }
        public IList<ColumnPairModel> Columns { get; } = new List<ColumnPairModel>();

        public EntityPairModel(int identifier, PlatformModel platform, ISqlEntityModel entity, EntityExpressionModel entityExpression)
        {
            Identifier = identifier;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            EntityExpression = entityExpression ?? throw new ArgumentNullException(nameof(entityExpression));
        }

        public override string ToString()
            => $"({Entity}, {EntityExpression})";
    }
}
