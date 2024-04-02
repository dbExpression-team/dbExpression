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

﻿using DbExpression.Tools.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace DbExpression.Tools.Builder
{
    public static class TypeModelBuilder
    {
        private static readonly Dictionary<SqlDbType, string> SqlDbTypeToSystemTypeMap = new()
        {
            { SqlDbType.BigInt, nameof(Int64) },
            { SqlDbType.Binary, "byte[]" },
            { SqlDbType.Image, "byte[]" },
            { SqlDbType.Timestamp, "byte[]" },
            { SqlDbType.VarBinary, "byte[]" },
            { SqlDbType.Bit, nameof(Boolean) },
            { SqlDbType.Char, nameof(String) },
            { SqlDbType.NChar, nameof(String) },
            { SqlDbType.NText, nameof(String) },
            { SqlDbType.NVarChar, nameof(String) },
            { SqlDbType.Text, nameof(String) },
            { SqlDbType.VarChar, nameof(String) },
            { SqlDbType.Date, nameof(DateTime) },
            { SqlDbType.DateTime, nameof(DateTime) },
            { SqlDbType.DateTime2, nameof(DateTime) },
            { SqlDbType.SmallDateTime, nameof(DateTime) },
            { SqlDbType.DateTimeOffset, nameof(DateTimeOffset) },
            { SqlDbType.Decimal, nameof(Decimal) },
            { SqlDbType.Float, nameof(Double) },
            { SqlDbType.Money, nameof(Double) },
            { SqlDbType.SmallMoney, nameof(Double) },
            { SqlDbType.Int, nameof(Int32) },
            { SqlDbType.SmallInt, nameof(Int16) },
            { SqlDbType.TinyInt, nameof(Byte) },
            { SqlDbType.UniqueIdentifier, nameof(Guid) },
            { SqlDbType.Real, nameof(Single) },
            { SqlDbType.Time, nameof(TimeSpan) }
        };

        public static TypeModel CreateTypeModel(LanguageFeaturesModel features, SqlDbType sqlType, string? clrTypeOverride, bool isDbNullable, bool isEnum)
        {
            string typeName = ResolveTypeName(sqlType, clrTypeOverride) ?? throw new NotImplementedException($"The sql database type {sqlType} is not compatible with dbExpression.");

            var isNullableType = IsNullableType(isDbNullable, clrTypeOverride);

            if (typeName.EndsWith("?"))
                typeName = typeName[0..^1];

            bool isArray = typeName.EndsWith("[]");
            if (isArray)
                typeName = typeName[0..^2];

            switch (typeName.ToLower())
            {
                case "bool":
                case "boolean": return new BooleanTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "byte": return new ByteTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "datetime": return new DateTimeTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "datetimeoffset": return new DateTimeOffsetTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "decimal": return new DecimalTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "double": return new DoubleTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "guid": return new GuidTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "short":
                case "int16":  return new Int16TypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "int":
                case "int32": return new Int32TypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "long":
                case "int64": return new Int64TypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "float":
                case "single": return new SingleTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "string": return new StringTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
                case "timespan": return new TimeSpanTypeModel(isNullableType, features.Nullable.IsFeatureEnabled, isArray);
            }
            if (isEnum)
                return new EnumTypeModel(typeName, isNullableType, features.Nullable.IsFeatureEnabled, isArray);

            return new UserDefinedTypeModel(typeName, isNullableType, features.Nullable.IsFeatureEnabled, isArray);
        }

        private static string? ResolveTypeName(SqlDbType sqlType, string? clrTypeOverride)
        {
            string? typeName = SqlDbTypeToSystemTypeMap.ContainsKey(sqlType) ? SqlDbTypeToSystemTypeMap[sqlType] : null;
            if (typeName is null)
                return typeName;
            if (!string.IsNullOrWhiteSpace(clrTypeOverride))
                typeName = clrTypeOverride;
            if (typeName.StartsWith("System."))
                typeName = typeName[7..];
            return typeName;
        }

        private static bool IsNullableType(bool isDbNullable, string? clrTypeOverride)
        {
            return (!string.IsNullOrEmpty(clrTypeOverride) && clrTypeOverride.EndsWith("?")) || (string.IsNullOrEmpty(clrTypeOverride) && isDbNullable);
        }
    }
}
