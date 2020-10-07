using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilder : SqlParameterBuilder
    {
        private readonly MsSqlTypeMaps typeMaps;

        public MsSqlParameterBuilder(MsSqlTypeMaps typeMaps)
        {
            this.typeMaps = typeMaps ?? throw new ArgumentNullException($"{nameof(typeMaps)} is required.");
        }

        public override DbParameter Add<T>(T value)
        {
            var typeMap = typeMaps.FindByClrType(typeof(T));

            var existing = FindExistingParameter(value, typeof(T), typeMap.DbType, ParameterDirection.Input, null, null, null);
            if (existing is object)
                return existing.Parameter;

            var parameter = Create(value, typeMap.PlatformType, null, null, null);
            var parameterized = new ParameterizedFieldExpression(typeof(T), parameter, null, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override DbParameter Add(object value, Type valueType)
        {
            var typeMap = typeMaps.FindByClrType(valueType);

            var existing = FindExistingParameter(value, valueType, typeMap.DbType, ParameterDirection.Input, null, null, null);
            if (existing is object)
                return existing.Parameter;

            var parameter = Create(value, typeMap.PlatformType, null, null, null);
            var parameterized = new ParameterizedFieldExpression(valueType, parameter, null, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override ParameterizedFieldExpression Add<T>(T value, FieldExpression field, ISqlFieldMetadata meta)
        {
            var typeMap = typeMaps.FindByPlatformType((SqlDbType)meta.DbType);

            var existing = FindExistingParameter(value, typeof(T), typeMap.DbType, ParameterDirection.Input, meta.Size, meta.Precision, meta.Scale);
            if (existing is object)
                return existing;

            var parameter = Create(value, typeMap.PlatformType, meta.Size, meta.Precision, meta.Scale);
            var parameterized = new ParameterizedFieldExpression(typeof(T), parameter, field, meta);
            Parameters.Add(parameterized);
            return parameterized;
        }

        public override ParameterizedFieldExpression AddOutput(FieldExpression field, ISqlFieldMetadata meta)
        {
            var parameter = new SqlParameter($"@P{Parameters.Count + 1}", (SqlDbType)meta.DbType) { Direction = ParameterDirection.Output };
            var parameterized = new ParameterizedFieldExpression((field as IExpressionTypeProvider).DeclaredType, parameter, field, meta);
            Parameters.Add(parameterized);
            return parameterized;
        }

        private DbParameter Create<T>(T value, SqlDbType dbType, int? size, byte? precision, byte? scale)
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
