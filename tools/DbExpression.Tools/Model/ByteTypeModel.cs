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


namespace DbExpression.Tools.Model
{
    public class ByteTypeModel : TypeModel
    {
        public override string TypeName => IsArray ? $"{base.TypeName}[]" : base.TypeName;
        public override string Alias => IsArray ? $"{base.Alias}[]" : base.Alias;

        public override string? Initializer
        {
            get
            {
                if (IsArray)
                    return IsNullableFeatureEnabled ? IsNullable ? "null" : $"new {Alias.Replace("[]", "[0]")}" : null;
                return IsNullable && IsNullableFeatureEnabled ? "null" : null;
            }
        }
        
        public ByteTypeModel(bool isNullable, bool isNullableFeatureEnabled, bool isArray) : base("Byte", "byte", isNullable, isNullableFeatureEnabled, isArray)
        {

        }
    }


}
