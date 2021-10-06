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

﻿namespace HatTrick.DbEx.Tools.Model
{
    public class TypeModel
    { 
        public string TypeName { get; private set; }
        public string Alias { get; private set; }
        public string NullableAlias { get; private set; }
        public bool IsNullable { get; private set; }
        public bool IsArray { get; private set; }
        public bool IsEnum { get; private set; }

        public TypeModel(string typeName, string alias, bool isNullable, bool isEnum = false, bool isArray = false)
        {
            TypeName = typeName;
            Alias = alias;
            NullableAlias = isNullable ? $"{alias}?" : alias;
            IsNullable = isNullable;
            IsEnum = isEnum;
            IsArray = isArray;
        }
    }
}
