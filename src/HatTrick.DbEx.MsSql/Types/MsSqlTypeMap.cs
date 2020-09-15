using HatTrick.DbEx.Sql.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Types
{
    public class MsSqlTypeMaps : DbTypeMaps<SqlDbType>
    {
        #region internals
        private static readonly HashSet<DbTypeMap<SqlDbType>> typeMaps = new HashSet<DbTypeMap<SqlDbType>>()
        {
            //reference: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
            new DbTypeMap<SqlDbType>(typeof(string), DbType.AnsiString, SqlDbType.VarChar),
            new DbTypeMap<SqlDbType>(typeof(char), DbType.AnsiString, SqlDbType.Char),
            new DbTypeMap<SqlDbType>(typeof(char[]), DbType.AnsiString, SqlDbType.VarChar),
            new DbTypeMap<SqlDbType>(typeof(int), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(decimal), DbType.Decimal, SqlDbType.Decimal),
            new DbTypeMap<SqlDbType>(typeof(DateTime), DbType.DateTime, SqlDbType.DateTime),
            new DbTypeMap<SqlDbType>(typeof(DateTimeOffset), DbType.DateTimeOffset, SqlDbType.DateTimeOffset),
            new DbTypeMap<SqlDbType>(typeof(bool), DbType.Boolean, SqlDbType.Bit),
            new DbTypeMap<SqlDbType>(typeof(byte), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(long), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(double), DbType.Double, SqlDbType.Float),
            new DbTypeMap<SqlDbType>(typeof(float), DbType.Single, SqlDbType.Real),
            new DbTypeMap<SqlDbType>(typeof(short), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(Guid), DbType.Guid, SqlDbType.UniqueIdentifier),
            new DbTypeMap<SqlDbType>(typeof(byte[]), DbType.Binary, SqlDbType.VarBinary),
            new DbTypeMap<SqlDbType>(typeof(ushort), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(sbyte), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(uint), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(TimeSpan), DbType.Time, SqlDbType.Time),

            new DbTypeMap<SqlDbType>(typeof(int?), DbType.Int32, SqlDbType.Int),
            new DbTypeMap<SqlDbType>(typeof(bool?), DbType.Boolean, SqlDbType.Bit),
            new DbTypeMap<SqlDbType>(typeof(DateTime?), DbType.DateTime, SqlDbType.DateTime),
            new DbTypeMap<SqlDbType>(typeof(decimal?), DbType.Decimal, SqlDbType.Decimal),
            new DbTypeMap<SqlDbType>(typeof(long?), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(ulong?), DbType.Int64, SqlDbType.BigInt),
            new DbTypeMap<SqlDbType>(typeof(double?), DbType.Double, SqlDbType.Float),
            new DbTypeMap<SqlDbType>(typeof(float?), DbType.Single, SqlDbType.Real),
            new DbTypeMap<SqlDbType>(typeof(short?), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(ushort?), DbType.Int16, SqlDbType.SmallInt),
            new DbTypeMap<SqlDbType>(typeof(byte?), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(sbyte?), DbType.Byte, SqlDbType.TinyInt),
            new DbTypeMap<SqlDbType>(typeof(uint?), DbType.Int32, SqlDbType.Int),
        };
        #endregion

        #region methods
        public override DbTypeMap<SqlDbType> FindByDbType(DbType dbType)
            => typeMaps.FirstOrDefault(x => x.DbType == dbType);

        public override DbTypeMap<SqlDbType> FindByPlatformType(SqlDbType dbType)
            => typeMaps.FirstOrDefault(x => x.PlatformType == dbType);

        public override DbTypeMap<SqlDbType> FindByClrType(Type clrType)
        {
            var existing = typeMaps.FirstOrDefault(x => x.ClrType == clrType);
            if (existing is object)
                return existing;

            if (clrType.IsEnum)
                return typeMaps.FirstOrDefault(x => x.ClrType == typeof(long));

            return null;
        }
        #endregion
    }
}
