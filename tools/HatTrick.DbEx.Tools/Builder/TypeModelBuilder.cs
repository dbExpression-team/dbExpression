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

﻿using HatTrick.DbEx.Tools.Model;
using HatTrick.Model.MsSql;
using System;
using System.Collections.Generic;
using System.Data;

namespace HatTrick.DbEx.Tools.Builder
{
    public static class TypeModelBuilder
    {
        private static readonly Dictionary<string,Type> KnownTypes = new()
        { 
            { nameof(Boolean), typeof(bool) },
            { "bool", typeof(bool) },
            { nameof(Byte), typeof(byte) },
            { "byte", typeof(byte) },
            { "ByteArray", typeof(byte[]) },
            { nameof(DateTime), typeof(DateTime) },
            { nameof(DateTimeOffset), typeof(DateTimeOffset) },
            { nameof(Decimal), typeof(decimal) },
            { "decimal", typeof(decimal) },
            { nameof(Double), typeof(double) },
            { "double", typeof(double) },
            { nameof(Guid), typeof(Guid) },
            { nameof(Single), typeof(float) },
            { "float", typeof(float) },
            { nameof(Int64), typeof(long) },
            { "long", typeof(long) },
            { nameof(Int32), typeof(int) },
            { "int", typeof(int) },
            { nameof(Int16), typeof(short) },
            { "short", typeof(short) },
            { nameof(String), typeof(string) },
            { "string", typeof(string) },
            { nameof(TimeSpan), typeof(TimeSpan) }
        };

        private static readonly Dictionary<string, string> TypeNameConversions = new()
        {
            { "bool", nameof(Boolean) },
            { "byte", nameof(Byte) },
            { "decimal", nameof(Decimal) },
            { "double", nameof(Double) },
            { "float", nameof(Single) },
            { "long", nameof(Int64) },
            { "int", nameof(Int32) },
            { "short", nameof(Int16) },
            { "string", nameof(String) }
        };

        private static readonly Dictionary<string, string> Aliases = new()
        {
            { nameof(Boolean), "bool" },
            { "bool", "bool" },
            { nameof(Byte), "byte" },
            { "byte", "byte" },
            { "ByteArray", "byte[]" },
            { nameof(Decimal), "decimal" },
            { "decimal", "decimal" },
            { nameof(Double), "double" },
            { "double", "double" },
            { nameof(Single), "float" },
            { "float", "float" },
            { nameof(Int64), "long" },
            { "long", "long" },
            { nameof(Int32), "int" },
            { "int", "int" },
            { nameof(Int16), "short" },
            { "short", "short" },
            { nameof(String), "string" },
            { "string", "string" }
        };

        private static readonly Dictionary<SqlDbType, string> SqlDbTypeToSystemTypeMap = new()
        {
            { SqlDbType.BigInt, nameof(Int64) },
            { SqlDbType.Binary, "ByteArray" },
            { SqlDbType.Image, "ByteArray" },
            { SqlDbType.Timestamp, "ByteArray" },
            { SqlDbType.VarBinary, "ByteArray" },
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

        public static TypeModel CreateTypeModel(LanguageFeatures features, SqlDbType sqlType, string? clrTypeOverride, bool isNullable, TypeSpecialCase? specialCase)
        {
            string typeName = ResolveTypeName(sqlType, clrTypeOverride) 
                ?? throw new NotImplementedException($"The sql database type {sqlType} is not compatible with dbExpression.");

            bool isArray = typeName.EndsWith("Array");
            if (isArray)
                isNullable = (features.Nullable.IsFeatureEnabled && isNullable) || isNullable;

            Type? knownType = KnownTypes.ContainsKey(typeName) ? KnownTypes[typeName] : null;
            if (specialCase is null)
            {
                if (knownType == typeof(string))
                {
                    specialCase = TypeSpecialCase.String;
                }
                else if (knownType is null)
                {
                    specialCase = TypeSpecialCase.UserDefinedType;
                    isNullable = features.Nullable.IsFeatureEnabled;
                }
            }
            if (specialCase == TypeSpecialCase.String)
                isNullable = isNullable && features.Nullable.IsFeatureEnabled;

            if (isNullable && typeName.EndsWith("?"))
                typeName = typeName[0..^1];

            string alias = Aliases.ContainsKey(typeName) ? Aliases[typeName] : typeName;
            string nullableAlias = isNullable ? GetAlias(features, typeName, alias, isArray, specialCase) : alias;
            string? initializer = features.Nullable.IsFeatureEnabled ? GetInitializer(typeName, alias, isNullable, isArray) : null;

            return new TypeModel(typeName, alias, nullableAlias, initializer, isNullable, specialCase, isArray);
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
            if (TypeNameConversions.ContainsKey(typeName))
                typeName = TypeNameConversions[typeName];
            return typeName;
        }

        private static string? GetInitializer(string typeName, string alias, bool isNullable, bool isArray)
        {
            if (typeName == nameof(String)) return isNullable ? "null" : "string.Empty";
            if (isArray)
                return isNullable ? "null" : $"new {alias.Replace("[]", "[0]")}";
            return isNullable ? "null" : null;
        }

        private static string GetAlias(LanguageFeatures features, string typeName, string alias, bool isArray, TypeSpecialCase? specialCase)
        {
            if (specialCase is not null)
            { 
                if (specialCase.Value == TypeSpecialCase.Enum) return $"{alias}?";
                return features.Nullable.IsFeatureEnabled ? $"{alias}?" : alias;
            }

            if (KnownTypes.ContainsKey(typeName))
            {
                if (isArray) return features.Nullable.IsFeatureEnabled ? $"{alias}?" : alias;
                return $"{alias}?";
            }

            return alias;
        }
    }
}
