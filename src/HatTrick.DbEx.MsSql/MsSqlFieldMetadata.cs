using HatTrick.DbEx.Sql;
using System.Data;

namespace HatTrick.DbEx.MsSql.Expression
{
    public class MsSqlFieldMetadata : SqlFieldMetadata
    {

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string name, SqlDbType dbType)
            : base(parent, name, dbType)
        {
        }

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string name, SqlDbType dbType, int size)
            : base(parent, name, dbType, size)
        {
        }

        public MsSqlFieldMetadata(ISqlEntityMetadata parent, string name, SqlDbType dbType, byte precision, byte scale)
            : base(parent, name, dbType, precision, scale)
        {
        }
    }
}
