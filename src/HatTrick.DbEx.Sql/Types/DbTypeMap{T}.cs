using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Types
{
    public class DbTypeMap<T>
        where T : Enum
    {
        public Type ClrType { get; }
        public DbType DbType { get; }
        public T PlatformType { get; }

        public DbTypeMap(Type clrType, DbType dbType, T platformType)
        {
            ClrType = clrType;
            DbType = dbType;
            PlatformType = platformType;
        }
    }

    public abstract class DbTypeMaps<T>
        where T : Enum
    {
        public abstract DbTypeMap<T> FindByDbType(DbType dbType);
        public abstract DbTypeMap<T> FindByPlatformType(T platformType);
        public abstract DbTypeMap<T> FindByClrType(Type clrType);
    }
}
