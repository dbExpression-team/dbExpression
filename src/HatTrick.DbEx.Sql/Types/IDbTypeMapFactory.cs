using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Types
{
    public interface IDbTypeMapFactory<T>
        where T : Enum
    {
        DbTypeMap<T> FindByDbType(DbType dbType);
        DbTypeMap<T> FindByPlatformType(T platformType);
        DbTypeMap<T> FindByClrType(Type clrType);
    }
}
