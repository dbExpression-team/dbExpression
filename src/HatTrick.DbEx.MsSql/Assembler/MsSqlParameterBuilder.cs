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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Types;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilder : SqlParameterBuilder, ISqlParameterBuilder
    {
        #region internals
        private readonly IDbTypeMapFactory<SqlDbType> typeMaps;
        private readonly IValueConverterFactory valueConverterFactory;
        #endregion

        #region constructors
        public MsSqlParameterBuilder(IDbTypeMapFactory<SqlDbType> typeMaps, IValueConverterFactory valueConverterFactory)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException(nameof(typeMaps));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }
        #endregion

        #region methods
        #region direction = input
        public virtual ParameterizedExpression CreateInputParameter<T>(T value, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, context, ParameterDirection.Input);

        public virtual ParameterizedExpression CreateInputParameter(object value, Type valueType, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, valueType, context, ParameterDirection.Input);

        public virtual ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, declaredType, (SqlDbType)meta.DbType, meta, meta.Size, meta.Precision, meta.Scale, context, ParameterDirection.Input);

        public virtual ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context)
            => CreateParameter(meta.Name, value, declaredType, (SqlDbType)meta.DbType, meta, meta.Size, meta.Precision, meta.Scale, context, ParameterDirection.Input);

        #endregion

        #region direction = input/output
        public virtual ParameterizedExpression CreateInputOutputParameter<T>(T value, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, context, ParameterDirection.InputOutput);

        public virtual ParameterizedExpression CreateInputOutputParameter(object value, Type valueType, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, valueType, context, ParameterDirection.InputOutput);

        public virtual ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => CreateParameter(CreateParameterName(), value, declaredType, (SqlDbType) meta.DbType, meta, meta.Size, meta.Precision, meta.Scale, context, ParameterDirection.InputOutput);

        public virtual ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlParameterMetadata meta, AssemblyContext context)
        {
            var parameter = CreateParameter(meta.Name, value, declaredType, (SqlDbType)meta.DbType, meta, meta.Size, meta.Precision, meta.Scale, context, ParameterDirection.InputOutput);
            parameter.Parameter.ParameterName = meta.Name;
            return parameter;
        }
        #endregion

        #region direction = output
        public ParameterizedExpression CreateOutputParameter(Type valueType, ISqlFieldMetadata meta, AssemblyContext context)
            => CreateParameter(CreateParameterName(), valueType, (SqlDbType)meta.DbType, meta.Size, meta.Precision, meta.Scale, ParameterDirection.Output);

        public ParameterizedExpression CreateOutputParameter(Type valueType, ISqlParameterMetadata meta, AssemblyContext context)
        {
            var parameter = CreateParameter(meta.Name, valueType, (SqlDbType)meta.DbType, meta.Size, meta.Precision, meta.Scale, ParameterDirection.Output);
            parameter.Parameter.ParameterName = meta.Name;
            return parameter;
        }
        #endregion

        protected virtual ParameterizedExpression CreateParameter<T>(string name, T value, AssemblyContext context, ParameterDirection direction)
        {
            var valueType = value is not null ? value.GetType() : typeof(T);
            var (convertedType, convertedValue) = ConvertDbParameterValue(valueType, value);
            var typeMap = typeMaps.FindByClrType(convertedType) ?? typeMaps.FindByClrType(valueType)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {typeof(T)}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(convertedValue, convertedType, typeMap.DbType, direction, null, null, null);
                if (existing?.Parameter is not null)
                    return existing;
            }

            var parameter = CreateDbParameter(name, convertedValue, typeMap.PlatformType, null, null, null, direction);
            return new(convertedType, parameter);
        }

        protected virtual ParameterizedExpression CreateParameter(string name, object value, Type valueType, AssemblyContext context, ParameterDirection direction)
        {
            var (convertedType, convertedValue) = ConvertDbParameterValue(valueType, value);
            var typeMap = typeMaps.FindByClrType(convertedType) ?? typeMaps.FindByClrType(valueType)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {valueType}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(convertedValue, convertedType, typeMap.DbType, direction, null, null, null);
                if (existing?.Parameter is not null)
                    return existing;
            }

            var parameter = CreateDbParameter(name, convertedValue, typeMap.PlatformType, null, null, null, direction);
            return new(convertedType, parameter);
        }

        protected virtual ParameterizedExpression CreateParameter<T>(string name, T value, Type declaredType, SqlDbType sqlDbType, ISqlMetadata meta, int? size, byte? precision, byte? scale, AssemblyContext context, ParameterDirection direction)
        {
            var (convertedType, convertedValue) = ConvertDbParameterValue(declaredType, value);
            var typeMap = typeMaps.FindByPlatformType(sqlDbType) ?? typeMaps.FindByClrType(convertedType)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the {nameof(SqlDbType)} {sqlDbType}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(convertedValue, convertedType, typeMap.DbType, direction, size, precision, scale);
                if (existing?.Parameter is not null)
                    return existing;
            }

            var parameter = CreateDbParameter(name, convertedValue, typeMap.PlatformType, size, precision, scale, direction);
            return new(typeMap.ClrType, parameter, meta);
        }

        protected virtual ParameterizedExpression CreateParameter(string name, Type valueType, SqlDbType sqlDbType, int? size, byte? precision, byte? scale, ParameterDirection direction)
            => new(valueType, CreateDbParameter(name, sqlDbType, size, precision, scale, ParameterDirection.Output));

        protected virtual (Type ConvertedType, object? ConvertedValue) ConvertDbParameterValue<T>(Type type, T? value)
            => ConvertDbParameterValue(type, value, valueConverterFactory.CreateConverter(type));

        protected virtual (Type ConvertedType, object? ConvertedValue) ConvertDbParameterValue(Type type, object? value)
            => ConvertDbParameterValue(type, value, valueConverterFactory.CreateConverter(type));

        protected virtual (Type ConvertedType, object? ConvertedValue) ConvertDbParameterValue(Type type, object? value, IValueConverter converter)
        {
            var converted = value is NullElement || value is null ? converter.ConvertToDatabase(null) : converter.ConvertToDatabase(value);
            if (converted.ConvertedValue is null)
                converted.ConvertedValue = DBNull.Value;
            return (converted.ConvertedValue.GetType(), converted.ConvertedValue);
        }

        protected virtual DbParameter CreateDbParameter<T>(string name, T value, SqlDbType dbType, int? size, byte? precision, byte? scale, ParameterDirection direction)
        {
            //if a sizable value is passed in with length of zero (i.e. string.Empty) we must switch the SqlDbType to the variable 
            //type or the framework will default the parameter size to Max (i.e. Char(8000)).

            //database column may be out of sync with metadata and the database may actually be able to hold the value that
            //has a length greater than that specified by metadata.  let sql server decide if it can handle the value or
            //throw an exception
            if (value is string stringValue)
            {
                if (!size.HasValue || size < stringValue.Length)
                {
                    size = stringValue.Length;
                }
                if (size == 0)
                {
                    size = 1;
                    dbType = SqlDbType.VarChar;
                }
            }
            else if (value is byte[] byteValue)
            {
                if (!size.HasValue || size < byteValue.Length)
                {
                    size = byteValue.Length;
                }
                if (size == 0)
                {
                    size = 1;
                    dbType = SqlDbType.VarBinary;
                }
            }

            var parameter = CreateDbParameter(name, dbType, size, precision, scale, direction);
            parameter.Value = value;

            return parameter;
        }

        protected virtual DbParameter CreateDbParameter(string name, SqlDbType dbType, int? size, byte? precision, byte? scale, ParameterDirection direction)
        {
            var parameter = new SqlParameter(name, dbType) { Direction = direction };

            if (size.HasValue)
                parameter.Size = size.Value;
            if (precision.HasValue)
                parameter.Precision = precision.Value;
            if (scale.HasValue)
                parameter.Scale = scale.Value;
            return parameter;
        }

        protected virtual string CreateParameterName() => $"@P{Parameters.Count + 1}";
        #endregion
    }
}
