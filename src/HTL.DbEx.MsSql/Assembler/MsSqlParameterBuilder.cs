using HTL.DbEx.MsSql.Types;
using HTL.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace HTL.DbEx.MsSql.Assembler
{
    public class MsSqlParameterBuilder : SqlParameterBuilder
    {
        public MsSqlParameterBuilder() : base(new List<SqlParameter>().Cast<DbParameter>().ToList())
        {

        }

        public MsSqlParameterBuilder(IList<SqlParameter> parameters) : base(parameters.Cast<DbParameter>().ToList())
        {

        }

        public override DbParameter Add(object value, Type valueType, int? size)
        {
            object val = (value == null) ? DBNull.Value : value;
            if (MsSqlTypeMap.IsSqlTypeKnown(valueType))
            {
                if (size.HasValue)
                {
                    var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", MsSqlTypeMap.GetSqlType(valueType), size.Value) { Value = val };
                    Parameters.Add(parameter);
                    return parameter;
                }
                else
                {
                    var parameter = new SqlParameter($"@P{(Parameters.Count + 1)}", MsSqlTypeMap.GetSqlType(valueType)) { Value = val };
                    Parameters.Add(parameter);
                    return parameter;
                }
            }
            return new SqlParameter($"@P{(Parameters.Count + 1)}", val);
        }
    }
}
