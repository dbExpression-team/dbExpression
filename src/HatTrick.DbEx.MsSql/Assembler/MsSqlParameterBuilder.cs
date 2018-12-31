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
        public MsSqlParameterBuilder() : base(new List<SqlParameter>().Cast<DbParameter>().ToList())
        {

        }

        public MsSqlParameterBuilder(IList<SqlParameter> parameters) : base(parameters.Cast<DbParameter>().ToList())
        {

        }

        public override DbParameter Add<T>(object value)
        {
           return Add(value, MsSqlTypeMap.GetSqlType(typeof(T)), null, null, null);
        }

        public override DbParameter Add(object value, Type valueType)
        {
            return Add(value, MsSqlTypeMap.GetSqlType(valueType), null, null, null);
        }

        public override DbParameter Add(object value, ISqlFieldMetadata metadata)
        {
            return Add(value, (SqlDbType)metadata.DbType, metadata.Size, metadata.Precision, metadata.Scale);
        }

        private DbParameter Add(object value, SqlDbType dbType, int? size, byte? precision, byte? scale)
        {
            object val = value ?? DBNull.Value;
            var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", dbType) { Value = val };
            if (size.HasValue)
                parameter.Size = size.Value;
            if (precision.HasValue)
                parameter.Precision = precision.Value;
            if (scale.HasValue)
                parameter.Scale = scale.Value;
            Parameters.Add(parameter);
            return parameter;
        }
    }
}
