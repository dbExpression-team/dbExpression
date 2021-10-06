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

﻿using HatTrick.DbEx.Tools.Builder;
using HatTrick.Model.MsSql;

namespace HatTrick.DbEx.Tools.Model
{
    public class FieldExpressionModel
    {
        public EntityExpressionModel EntityExpression { get; }
        public string Name { get; }
        public TypeModel Type { get; }
        public bool AllowInsert { get; }
        public bool AllowUpdate { get; }
        public (string,string) CrefTypeName
        {
            get
            {
                if (Type.IsArray)
                    return (Type.Alias[0..^2], "[]");
                if (Type.IsNullable)
                    return (Type.Alias, "?");

                return (Type.Alias, null);
            }
        }

        public FieldExpressionModel(EntityExpressionModel entity, MsSqlColumn column, string name, string clrTypeOverride, bool isEnum, bool allowInsert, bool allowUpdate)
        {
            EntityExpression = entity;
            Name = name;
            Type = TypeModelBuilder.CreateTypeModel(column.SqlType, clrTypeOverride, column.IsNullable, isEnum);
            AllowInsert = allowInsert;
            AllowUpdate = allowUpdate;
        }

        public override string ToString()
            => $"{Name}Field";
    }
}
