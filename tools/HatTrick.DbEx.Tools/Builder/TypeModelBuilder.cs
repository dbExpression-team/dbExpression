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
        private static Func<bool, TypeModel> NewBooleanTypeModel = isNullable => new TypeModel(nameof(Boolean), "bool", isNullable);
        private static Func<bool, TypeModel> NewByteTypeModel = isNullable => new TypeModel(nameof(Byte), "byte", isNullable);
        private static Func<bool, TypeModel> NewByteArrayTypeModel = isNullable => new TypeModel("ByteArray", "byte[]", isNullable:false, isEnum:false, isArray:true);
        private static Func<bool, TypeModel> NewDateTimeTypeModel = isNullable => new TypeModel(nameof(DateTime), nameof(DateTime), isNullable);
        private static Func<bool, TypeModel> NewDateTimeOffsetTypeModel = isNullable => new TypeModel(nameof(DateTimeOffset), nameof(DateTimeOffset), isNullable);
        private static Func<bool, TypeModel> NewDecimalTypeModel = isNullable => new TypeModel(nameof(Decimal), "decimal", isNullable);
        private static Func<bool, TypeModel> NewDoubleTypeModel = isNullable => new TypeModel(nameof(Double), "double", isNullable);
        private static Func<bool, TypeModel> NewSingleTypeModel = isNullable => new TypeModel(nameof(Single), "float", isNullable);
        private static Func<bool, TypeModel> NewGuidTypeModel = isNullable => new TypeModel(nameof(Guid), nameof(Guid), isNullable);
        private static Func<bool, TypeModel> NewInt64TypeModel = isNullable => new TypeModel(nameof(Int64), "long", isNullable);
        private static Func<bool, TypeModel> NewInt32TypeModel = isNullable => new TypeModel(nameof(Int32), "int", isNullable);
        private static Func<bool, TypeModel> NewObjectTypeModel = isNullable => new TypeModel(nameof(Object), "object", false);
        private static Func<bool, TypeModel> NewInt16TypeModel = isNullable => new TypeModel(nameof(Int16), "short", isNullable);
        private static Func<bool, TypeModel> NewStringTypeModel = isNullable => new TypeModel(nameof(String), "string", false);
        private static Func<bool, TypeModel> NewTimeSpanTypeModel = isNullable => new TypeModel(nameof(TimeSpan), nameof(TimeSpan), true);

        private static IDictionary<string,Func<bool, TypeModel>> TypeModelFactories = new Dictionary<string,Func<bool, TypeModel>>();

        static TypeModelBuilder()
        {
            TypeModelFactories.Add(nameof(Boolean), NewBooleanTypeModel);
            TypeModelFactories.Add("bool", NewBooleanTypeModel);

            TypeModelFactories.Add("byte", NewByteTypeModel);
            TypeModelFactories.Add(nameof(Byte), NewByteTypeModel);

            TypeModelFactories.Add("byte[]", NewByteArrayTypeModel);
            TypeModelFactories.Add("Byte[]", NewByteArrayTypeModel);
            TypeModelFactories.Add("ByteArray", NewByteArrayTypeModel);

            TypeModelFactories.Add(nameof(DateTime), NewDateTimeTypeModel);

            TypeModelFactories.Add(nameof(DateTimeOffset), NewDateTimeOffsetTypeModel);

            TypeModelFactories.Add(nameof(Decimal), NewDecimalTypeModel);
            TypeModelFactories.Add("decimal", NewDecimalTypeModel);

            TypeModelFactories.Add(nameof(Double), NewDoubleTypeModel);
            TypeModelFactories.Add("double", NewDoubleTypeModel);

            TypeModelFactories.Add(nameof(Single), NewSingleTypeModel);
            TypeModelFactories.Add("float", NewSingleTypeModel);

            TypeModelFactories.Add(nameof(Guid), NewGuidTypeModel);

            TypeModelFactories.Add(nameof(Int64), NewInt64TypeModel);
            TypeModelFactories.Add("long", NewInt64TypeModel);

            TypeModelFactories.Add(nameof(Int32), NewInt32TypeModel);
            TypeModelFactories.Add("int", NewInt32TypeModel);

            TypeModelFactories.Add(nameof(Int16), NewInt16TypeModel);
            TypeModelFactories.Add("short", NewInt16TypeModel);

            TypeModelFactories.Add(nameof(Object), NewObjectTypeModel);
            TypeModelFactories.Add("object", NewObjectTypeModel);

            TypeModelFactories.Add(nameof(String), NewStringTypeModel);
            TypeModelFactories.Add("string", NewStringTypeModel);

            TypeModelFactories.Add(nameof(TimeSpan), NewTimeSpanTypeModel);
        }

        public static TypeModel CreateTypeModel(SqlDbType sqlType, string clrTypeOverride, bool isNullable, bool isEnum)
        {
            if (string.IsNullOrWhiteSpace(clrTypeOverride))
                return TypeModelFactories[GetBySqlDbType(sqlType)](isNullable);

            if (clrTypeOverride.StartsWith("System."))
                clrTypeOverride = clrTypeOverride.Substring(7);

            isNullable = clrTypeOverride.EndsWith("?");
            if (isNullable)
                clrTypeOverride = clrTypeOverride.Substring(0, clrTypeOverride.Length - 1);

            if (TypeModelFactories.ContainsKey(clrTypeOverride))
                return TypeModelFactories[clrTypeOverride](isNullable);

            var nullableTypeModel = new TypeModel(clrTypeOverride, clrTypeOverride, true, isEnum, clrTypeOverride.Contains("[]"));
            var typeModel = new TypeModel(clrTypeOverride, clrTypeOverride, false, isEnum, clrTypeOverride.Contains("[]"));
            TypeModelFactories.Add(clrTypeOverride, _isNullable => _isNullable ? nullableTypeModel : typeModel);

            return TypeModelFactories[clrTypeOverride](isNullable);
        }

        private static string GetBySqlDbType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt: return nameof(Int64);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary: return "ByteArray";

                case SqlDbType.Bit: return nameof(Boolean);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar: return nameof(String);

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime: return nameof(DateTime);

                case SqlDbType.DateTimeOffset: return nameof(DateTimeOffset);

                case SqlDbType.Decimal: return nameof(Decimal);

                case SqlDbType.Float:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney: return nameof(Double);

                case SqlDbType.Int: return nameof(Int32);

                case SqlDbType.SmallInt: return nameof(Int16);

                case SqlDbType.TinyInt: return nameof(Byte);

                case SqlDbType.UniqueIdentifier: return nameof(Guid);

                case SqlDbType.Real: return nameof(Single);

                case SqlDbType.Time: return nameof(TimeSpan);

                case SqlDbType.Udt:
                case SqlDbType.Structured:
                case SqlDbType.Variant:
                case SqlDbType.Xml:
                default:
                    throw new NotImplementedException($"The sql database type {sqlType} is not compatible with dbExpression.");
            }
        }
    }
}
