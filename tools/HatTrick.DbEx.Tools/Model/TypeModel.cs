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

namespace HatTrick.DbEx.Tools.Model
{
    public abstract class TypeModel
    {
        protected readonly bool IsNullableFeatureEnabled;

        public virtual string TypeName { get; private set; }
        public virtual string Alias { get; private set; }
        public virtual string NullableAlias => IsNullable ? $"{Alias}?" : Alias;
        public virtual bool IsNullable { get; private set; }
        public virtual bool IsArray { get; private set; }
        public virtual bool IsSystemType => true;
        public virtual bool IsEnum => false;
        public virtual bool IsString => false;
        public virtual bool IsUserDefinedType => false;
        public virtual string? Initializer
        {
            get
            {
                if (IsArray)
                    throw new ArgumentException($"dbExpression does not support using type '{TypeName}' in arrays.");
                return IsNullable && IsNullableFeatureEnabled ? "null" : null;
            }
        }

        protected TypeModel(string typeName, string alias, bool isNullable, bool isNullableFeatureEnabled, bool isArray)
        {
            if (string.IsNullOrWhiteSpace(typeName))
                throw new ArgumentException($"{nameof(typeName)} is required.");
            if (string.IsNullOrWhiteSpace(alias))
                throw new ArgumentException($"{nameof(alias)} is required.");
            TypeName = typeName;
            Alias = alias;
            IsNullable = isNullable;
            IsNullableFeatureEnabled = isNullableFeatureEnabled;
            IsArray = isArray;
        }
    }
}
