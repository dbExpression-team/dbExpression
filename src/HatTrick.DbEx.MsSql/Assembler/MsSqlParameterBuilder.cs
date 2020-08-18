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
        public override DbParameter Add<T>(T value)
        {
            var parameter = Create(value, MsSqlTypeMap.GetSqlType(typeof(T)), null, null, null);
            var parameterized = new ParameterizedFieldExpression(parameter, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override DbParameter Add(object value, Type valueType)
        {
            var parameter = Create(value, MsSqlTypeMap.GetSqlType(valueType), null, null, null);
            var parameterized = new ParameterizedFieldExpression(parameter, null);
            Parameters.Add(parameterized);
            return parameter;
        }

        public override ParameterizedFieldExpression Add<T>(T value, FieldExpression field)
        {
            DbParameter parameter;
            if (field is object)
            {
                var metadata = (field as ISqlMetadataProvider<ISqlFieldMetadata>).Metadata;
                parameter = Create(value, (SqlDbType)metadata.DbType, metadata.Size, metadata.Precision, metadata.Scale);
            }
            else
            {
                parameter = Create(value, MsSqlTypeMap.GetSqlType(typeof(T)), null, null, null);
            }
            var parameterized = new ParameterizedFieldExpression(parameter, field);
            Parameters.Add(parameterized);
            return parameterized;
        }

        public override ParameterizedFieldExpression AddOutput(FieldExpression field)
        {
            var metadata = (field as ISqlMetadataProvider<ISqlFieldMetadata>).Metadata;
            var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", (SqlDbType)metadata.DbType) { Direction = ParameterDirection.Output };
            var parameterized = new ParameterizedFieldExpression(parameter, field);
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
