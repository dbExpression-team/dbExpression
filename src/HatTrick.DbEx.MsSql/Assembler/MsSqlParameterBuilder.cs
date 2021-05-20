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
        public virtual ParameterizedExpression CreateInputParameter<T>(T value, AssemblyContext context)
            => CreateParameter(value, context, ParameterDirection.Input);

        public virtual ParameterizedExpression CreateInputParameter(object value, Type valueType, AssemblyContext context)
            => CreateParameter(value, valueType, context, ParameterDirection.Input);

        public virtual ParameterizedExpression CreateInputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => CreateParameter(value, declaredType, meta, context, ParameterDirection.Input);

        public virtual void AddInputParameter<T>(T value, AssemblyContext context)
            => Parameters.Add(CreateInputParameter(value, context));

        public virtual void AddInputParameter(object value, Type valueType, AssemblyContext context)
            => Parameters.Add(CreateInputParameter(value, valueType, context));

        public virtual void AddInputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => Parameters.Add(CreateInputParameter(value, declaredType, meta, context));

        public virtual ParameterizedExpression CreateInputOutputParameter<T>(T value, AssemblyContext context)
            => CreateParameter(value, context, ParameterDirection.InputOutput);

        public virtual ParameterizedExpression CreateInputOutputParameter(object value, Type valueType, AssemblyContext context)
            => CreateParameter(value, valueType, context, ParameterDirection.InputOutput);

        public virtual ParameterizedExpression CreateInputOutputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => CreateParameter(value, declaredType, meta, context, ParameterDirection.InputOutput);

        public virtual void AddInputOutputParameter<T>(T value, AssemblyContext context)
            => Parameters.Add(CreateParameter(value, context, ParameterDirection.InputOutput));

        public virtual void AddInputOutputParameter(object value, Type valueType, AssemblyContext context)
            => Parameters.Add(CreateParameter(value, valueType, context, ParameterDirection.InputOutput));

        public virtual void AddInputOutputParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context)
            => Parameters.Add(CreateParameter(value, declaredType, meta, context, ParameterDirection.InputOutput));

        public ParameterizedExpression CreateOutputParameter<T>(AssemblyContext context)
            => CreateOutputParameter(typeof(T), context);

        public ParameterizedExpression CreateOutputParameter(Type valueType, AssemblyContext context)
        {
            var typeMap = typeMaps.FindByClrType(valueType)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the clr type {valueType}.  This is an internal issue that cannot be resolved; please report as an issue.");
            var parameter = CreateDbParameter(typeMap.PlatformType, valueType == typeof(string) ? 40 : (int?)null, null, null, ParameterDirection.Output);
            parameter.Direction = ParameterDirection.Output;
            return new ParameterizedExpression(typeMap.ClrType, parameter);
        }

        public void AddOutputParameter<T>(AssemblyContext context)
            => Parameters.Add(CreateOutputParameter<T>(context));
        public void AddOutputParameter(Type valueType, AssemblyContext context)
            => Parameters.Add(CreateParameter(valueType, context, ParameterDirection.InputOutput));

        protected virtual ParameterizedExpression CreateParameter<T>(T value, AssemblyContext context, ParameterDirection direction)
        {
            var (type, converted) = ConvertDbParameterValue(value is object ? value.GetType() : typeof(T), value);
            var typeMap = typeMaps.FindByClrType(type)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {typeof(T)}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(converted, type, typeMap.DbType, direction, null, null, null);
                if (existing?.Parameter is object)
                    return existing;
            }

            var parameter = CreateDbParameter(converted, typeMap.PlatformType, null, null, null, direction);
            return new ParameterizedExpression(type, parameter);
        }

        protected virtual ParameterizedExpression CreateParameter(object value, Type valueType, AssemblyContext context, ParameterDirection direction)
        {
            var (type, converted) = ConvertDbParameterValue(valueType, value);
            var typeMap = typeMaps.FindByClrType(type)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {valueType}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(converted, type, typeMap.DbType, direction, null, null, null);
                if (existing?.Parameter is object)
                    return existing;
            }

            var parameter = CreateDbParameter(converted, typeMap.PlatformType, null, null, null, direction);
            return new ParameterizedExpression(type, parameter);
        }

        protected virtual ParameterizedExpression CreateParameter<T>(T value, Type declaredType, ISqlFieldMetadata meta, AssemblyContext context, ParameterDirection direction)
        {
            var (type, converted) = ConvertDbParameterValue(declaredType, value);
            var typeMap = typeMaps.FindByPlatformType((SqlDbType)meta.DbType)
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the {nameof(SqlDbType)} {(SqlDbType)meta.DbType}.  This is an internal issue that cannot be resolved; please report as an issue.");

            if (context.TrySharingExistingParameter)
            {
                var existing = FindExistingParameter(converted, type, typeMap.DbType, direction, meta.Size, meta.Precision, meta.Scale);
                if (existing?.Parameter is object)
                    return existing;
            }

            var parameter = CreateDbParameter(converted, typeMap.PlatformType, meta.Size, meta.Precision, meta.Scale, direction);
            return new ParameterizedExpression(typeMap.ClrType, parameter, meta);
        }

        protected virtual (Type Type, object ConvertedValue) ConvertDbParameterValue<T>(Type type, T value)
            => ConvertDbParameterValue(type, value, valueConverterFactory.CreateConverter(type));

        protected virtual (Type Type, object ConvertedValue) ConvertDbParameterValue(Type type, object value)
        {
            if ((value is DBNull || value is null) && !type.IsNullableType())
            {
                return (type, value);
            }
            var converter = valueConverterFactory.CreateConverter(type);
            return ConvertDbParameterValue(type, value, converter);
        }

        protected virtual (Type Type, object ConvertedValue) ConvertDbParameterValue(Type type, object value, IValueConverter converter)
        {
            var converted = value is DBNull || !(value is object) ? converter.ConvertToDatabase(null) : converter.ConvertToDatabase(value);
            if (converted.ConvertedValue is null)
                converted.ConvertedValue = DBNull.Value;
            return converted;
        }

        protected virtual DbParameter CreateDbParameter<T>(T value, SqlDbType dbType, int? size, byte? precision, byte? scale, ParameterDirection direction)
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

            var parameter = CreateDbParameter(dbType, size, precision, scale, direction);
            parameter.Value = value;

            return parameter;
        }

        protected virtual DbParameter CreateDbParameter(SqlDbType dbType, int? size, byte? precision, byte? scale, ParameterDirection direction)
        {
            var parameter = new SqlParameter($"@P{Parameters.Count + 1}", dbType) { Direction = direction };

            if (size.HasValue)
                parameter.Size = size.Value;
            if (precision.HasValue)
                parameter.Precision = precision.Value;
            if (scale.HasValue)
                parameter.Scale = scale.Value;
            return parameter;
        }
        #endregion
    }
}
