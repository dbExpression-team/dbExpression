using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilder : SqlParameterBuilder
    {
        public MsSqlParameterBuilder()
        {

        }

        public override DbParameter Add<T>(object value)
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

        public override ParameterizedFieldExpression Add(object value, FieldExpression field)
        {
            var metadata = (field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;
            var parameter = Create(value, (SqlDbType)metadata.DbType, metadata.Size, metadata.Precision, metadata.Scale);
            var parameterized = new ParameterizedFieldExpression(parameter, field);
            Parameters.Add(parameterized);
            return parameterized;
        }

        public override ParameterizedFieldExpression AddOutput(FieldExpression field)
        {
            var metadata = (field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;
            var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", (SqlDbType)metadata.DbType) { Direction = ParameterDirection.Output };
            var parameterized = new ParameterizedFieldExpression(parameter, field);
            Parameters.Add(parameterized);
            return parameterized;
        }

        private DbParameter Create(object value, SqlDbType dbType, int? size, byte? precision, byte? scale)
        {
            object val = value ?? DBNull.Value;
            var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", dbType) { Value = val };
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
