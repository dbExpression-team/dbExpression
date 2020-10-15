using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Types;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilder : SqlParameterBuilder
    {
        private readonly IDbTypeMapFactory<SqlDbType> typeMaps;
        private readonly IValueConverterFactory valueConverterFactory;

        public MsSqlParameterBuilder(MsSqlTypeMaps typeMaps)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
            this.valueConverterFactory = valueConverterFactory;
        }

        public override DbParameter Add<T>(T value)
        {
            var (type, converted) = ConvertDbParameterValue(value);
            var typeMap = typeMaps.FindByClrType(typeof(T));
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {typeof(T)}.  This is an internal issue that cannot be resolved; please report as an issue.");

            var existing = FindExistingParameter(converted, type, typeMap.DbType, ParameterDirection.Input, null, null, null);
            if (existing is object)
                return existing.Parameter;

            var parameter = CreateDbParameter(converted, typeMap.PlatformType, null, null, null);
            var parameterized = new ParameterizedExpression(type, parameter, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override DbParameter Add(object value, Type valueType)
        {
            var (type, converted) = ConvertDbParameterValue(valueType, value);
            var typeMap = typeMaps.FindByClrType(valueType);
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the supplied clr type {valueType}.  This is an internal issue that cannot be resolved; please report as an issue.");

            var existing = FindExistingParameter(converted, type, typeMap.DbType, ParameterDirection.Input, null, null, null);
            if (existing is object)
                return existing.Parameter;

            var parameter = CreateDbParameter(converted, typeMap.PlatformType, null, null, null);
            var parameterized = new ParameterizedExpression(type, parameter, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override ParameterizedExpression Add<T>(T value, ISqlFieldMetadata meta)
        {
            var (type, converted) = ConvertDbParameterValue(value);
            var typeMap = typeMaps.FindByPlatformType((SqlDbType)meta.DbType) 
                ?? throw new DbExpressionException($"Type resolution failed, cannot construct a {nameof(SqlParameter)} based on the {nameof(SqlDbType)} {(SqlDbType)meta.DbType}.  This is an internal issue that cannot be resolved; please report as an issue.");
            
            var existing = FindExistingParameter(converted, type, typeMap.DbType, ParameterDirection.Input, meta.Size, meta.Precision, meta.Scale);
            if (existing is object)
                return existing;

            var parameter = CreateDbParameter(value, typeMap.PlatformType, meta.Size, meta.Precision, meta.Scale);
            var parameterized = new ParameterizedExpression(typeMap.ClrType, parameter, meta);
            Parameters.Add(parameterized);
            return parameterized;
        }

        private (Type, object) ConvertDbParameterValue<T>(T value)
        {
            if (value is DBNull || !(value is object))
            {
                return (typeof(T), value);
            }
            var converter = valueConverterFactory.CreateConverter(value.GetType());
            return converter.ConvertToDatabase(value);
        }

        private (Type, object) ConvertDbParameterValue(Type type, object value)
        {
            if (value is DBNull || value is null)
            {
                return (type, value);
            }
            var converter = valueConverterFactory.CreateConverter(type);
            return converter.ConvertToDatabase(value);
        }

        private DbParameter CreateDbParameter<T>(T value, SqlDbType dbType, int? size, byte? precision, byte? scale)
        {
            var parameter = new SqlParameter($"@P{Parameters.Count + 1}", dbType) { Value = value };

            if (size.HasValue)
                parameter.Size = size.Value;
            if (precision.HasValue)
                parameter.Precision = precision.Value;
            if (scale.HasValue)
                parameter.Scale = scale.Value;
            return parameter;
        }
    }
}
